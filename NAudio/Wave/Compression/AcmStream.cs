using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
    /// <summary>
    /// AcmStream encapsulates an Audio Compression Manager Stream
    /// used to convert audio from one format to another
    /// </summary>
    class AcmStream : IDisposable
    {
        private IntPtr streamHandle;
        private IntPtr driverHandle;
        private AcmStreamHeader streamHeader;

        /// <summary>
        /// Creates a new ACM stream to convert one format to another. Note that
        /// not all conversions can be done in one step
        /// </summary>
        /// <param name="sourceFormat">The source audio format</param>
        /// <param name="destFormat">The destination audio format</param>
        public AcmStream(WaveFormat sourceFormat, WaveFormat destFormat)
        {
            int sourceBufferSize = sourceFormat.AverageBytesPerSecond;
            sourceBufferSize -= (sourceBufferSize % sourceFormat.BlockAlign);
            MmException.Try(AcmInterop.acmStreamOpen(out streamHandle, IntPtr.Zero, sourceFormat, destFormat, null, 0, 0, AcmStreamOpenFlags.NonRealTime), "acmStreamOpen");
            streamHeader = new AcmStreamHeader(streamHandle, sourceBufferSize, SourceToDest(sourceBufferSize));
            driverHandle = IntPtr.Zero;
        }

        public AcmStream(int driverId, WaveFormat sourceFormat, WaveFilter waveFilter)
        {
            int sourceBufferSize = sourceFormat.AverageBytesPerSecond;
            sourceBufferSize -= (sourceBufferSize % sourceFormat.BlockAlign);
            MmException.Try(AcmInterop.acmDriverOpen(out driverHandle, driverId, 0), "acmDriverOpen");
            MmException.Try(AcmInterop.acmStreamOpen(out streamHandle, driverHandle,
                          sourceFormat, sourceFormat, waveFilter, 0, 0, AcmStreamOpenFlags.NonRealTime), "acmStreamOpen");
            streamHeader = new AcmStreamHeader(streamHandle, sourceBufferSize, SourceToDest(sourceBufferSize));
        }

        /// <summary>
        /// Returns the number of output bytes for a given number of input bytes
        /// </summary>
        /// <param name="source">Number of input bytes</param>
        /// <returns>Number of output bytes</returns>
        public int SourceToDest(int source)
        {
            if (source == 0) // zero is an invalid parameter to acmStreamSize
                return 0;
            int convertedBytes;
            MmException.Try(AcmInterop.acmStreamSize(streamHandle, (int)source, out convertedBytes, AcmStreamSizeFlags.Source), "acmStreamSize");
            return convertedBytes;
        }

        /// <summary>
        /// Returns the number of source bytes for a given number of destination bytes
        /// </summary>
        /// <param name="dest">Number of destination bytes</param>
        /// <returns>Number of source bytes</returns>
        public int DestToSource(int dest)
        {
            if (dest == 0) // zero is an invalid parameter to acmStreamSize
                return 0;
            int convertedBytes;
            MmException.Try(AcmInterop.acmStreamSize(streamHandle, (int)dest, out convertedBytes, AcmStreamSizeFlags.Destination), "acmStreamSize");
            return convertedBytes;
        }

        /// <summary>
        /// Suggests an appropriate PCM format that the compressed format can be converted
        /// to in one step
        /// </summary>
        /// <param name="compressedFormat">The compressed format</param>
        /// <returns>The PCM format</returns>
        public static WaveFormat SuggestPcmFormat(WaveFormat compressedFormat)
        {
            // create a PCM format
            WaveFormat suggestedFormat = new WaveFormat(compressedFormat.SampleRate, 16, compressedFormat.Channels);
            MmException.Try(AcmInterop.acmFormatSuggest(IntPtr.Zero, compressedFormat, suggestedFormat, Marshal.SizeOf(suggestedFormat), AcmFormatSuggestFlags.FormatTag), "acmFormatSuggest");
            return suggestedFormat;
        }

        /// <summary>
        /// Returns the Source Buffer. Fill this with data prior to calling convert
        /// </summary>
        public byte[] SourceBuffer
        {
            get
            {
                return streamHeader.SourceBuffer;
            }
        }

        /// <summary>
        /// Returns the Destination buffer. This will contain the converted data
        /// after a successful call to Convert
        /// </summary>
        public byte[] DestBuffer
        {
            get
            {
                return streamHeader.DestBuffer;
            }
        }

        /// <summary>
        /// Converts the contents of the SourceBuffer into the DestinationBuffer
        /// </summary>
        /// <param name="bytesToConvert">The number of bytes in the SourceBuffer
        /// that need to be converted</param>
        /// <returns>The number of converted bytes in the DestinationBuffer</returns>
        public int Convert(int bytesToConvert)
        {
            return streamHeader.Convert(bytesToConvert);
        }

        /* Relevant only for async conversion streams
        public void Reset()
        {
            MmException.Try(AcmInterop.acmStreamReset(streamHandle,0),"acmStreamReset");
        }
        */

        #region IDisposable Members

        /// <summary>
        /// Frees resources associated with this ACM Stream
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Frees resources associated with this ACM Stream
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Free other state (managed objects).
                if (streamHeader != null)
                {
                    streamHeader.Dispose();
                    streamHeader = null;
                }
            }

            // Free your own state (unmanaged objects).

            if (streamHandle != IntPtr.Zero)
            {
                MmResult result = AcmInterop.acmStreamClose(streamHandle, 0);
                streamHandle = IntPtr.Zero;
                if (result != MmResult.NoError)
                {
                    throw new MmException(result, "acmStreamClose");
                }

            }
            // Set large fields to null.
            if (driverHandle != IntPtr.Zero)
            {
                AcmInterop.acmDriverClose(driverHandle, 0);
                driverHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Frees resources associated with this ACM Stream
        /// </summary>
        ~AcmStream()
        {
            // Simply call Dispose(false).
            System.Diagnostics.Debug.Assert(false, "AcmStream Dispose was not called");
            Dispose(false);
        }

        #endregion
    }
}
