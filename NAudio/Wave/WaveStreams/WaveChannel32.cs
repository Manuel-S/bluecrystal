using System;

namespace NAudio.Wave
{
    /// <summary>
    /// Represents Channel for the WaveMixerStream
    /// 32 bit output and 16 bit input
    /// It's output is always stereo
    /// The input stream can be panned
    /// </summary>
    public class WaveChannel32 : WaveStream
    {
        private WaveStream sourceStream;
        private readonly long audioStartPosition;
        private readonly WaveFormat waveFormat;
        private readonly long length;
        private readonly int destBytesPerSample;

        private volatile float volume;
        private volatile float pan;
        private long position;

        /// <summary>
        /// Creates a new WaveChannel32
        /// </summary>
        /// <param name="sourceStream">the source stream</param>
        /// <param name="volume">stream volume (1 is 0dB)</param>
        /// <param name="pan">pan control (-1 to 1)</param>
        /// <param name="offset">amount of silence before start</param>
        public WaveChannel32(WaveStream sourceStream, float volume, float pan, TimeSpan offset)
        {
            if (sourceStream.WaveFormat.Encoding != WaveFormatEncoding.Pcm)
                throw new ApplicationException("Only PCM supported");
            if (sourceStream.WaveFormat.BitsPerSample != 16)
                throw new ApplicationException("Only 16 bit audio supported");
            int silenceSamples = (int) (offset.TotalSeconds * sourceStream.WaveFormat.SampleRate);

            // always outputs stereo 32 bit
            waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sourceStream.WaveFormat.SampleRate, 2);

            this.sourceStream = sourceStream;
            this.volume = volume;
            this.pan = pan;

            destBytesPerSample = 4;
            audioStartPosition = silenceSamples * 2 * destBytesPerSample;
            length = audioStartPosition + 2 * sourceStream.Length * ((sourceStream.WaveFormat.Channels == 1) ? 2 : 1);
            position = 0;
        }

        /// <summary>
        /// Gets the block alignment for this WaveStream
        /// </summary>
        public override int BlockAlign
        {
            get
            {
                return sourceStream.BlockAlign * ((sourceStream.WaveFormat.Channels == 1) ? 4 : 2);
            }
        }

        /// <summary>
        /// Returns the stream length
        /// </summary>
        public override long Length
        {
            get
            {
                return length;
            }
        }

        /// <summary>
        /// Gets or sets the current position in the stream
        /// </summary>
        public override long Position
        {
            get
            {
                return position;
            }
            set
            {
                lock (this)
                {
                    // make sure we don't get out of sync
                    value -= (value % BlockAlign);
                    if (value < audioStartPosition)
                        sourceStream.Position = 0;
                    else if (sourceStream.WaveFormat.Channels == 1)
                        sourceStream.Position = (value - audioStartPosition) / 4;
                    else
                        sourceStream.Position = (value - audioStartPosition) / 2;
                    position = value;
                }
            }
        }

        /// <summary>
        /// Reads bytes from this wave stream
        /// </summary>
        /// <param name="destBuffer">The destination buffer</param>
        /// <param name="offset">Offset into the destination buffer</param>
        /// <param name="numBytes">Number of bytes read</param>
        /// <returns>Number of bytes read.</returns>
        public override int Read(byte[] destBuffer, int offset, int numBytes)
        {
            int bytesWritten = 0;
            // 1. fill with silence
            if (position < audioStartPosition)
            {
                bytesWritten = (int)Math.Min(numBytes, audioStartPosition - position);
                for (int n = 0; n < bytesWritten; n++)
                    destBuffer[n + offset] = 0;
            }
            if (bytesWritten < numBytes)
            {
                if (sourceStream.WaveFormat.Channels == 1)
                {
                    int sourceBytesRequired = (numBytes - bytesWritten) / 4;
                    byte[] sourceBuffer = new byte[sourceBytesRequired];
                    int read = sourceStream.Read(sourceBuffer, 0, sourceBytesRequired);
                    MonoToStereo(destBuffer, offset + bytesWritten, sourceBuffer, read);
                    bytesWritten += (read * 4);
                }
                else
                {
                    int sourceBytesRequired = (numBytes - bytesWritten) / 2;
                    byte[] sourceBuffer = new byte[sourceBytesRequired];
                    int read = sourceStream.Read(sourceBuffer, 0, sourceBytesRequired);
                    AdjustVolume(destBuffer, offset + bytesWritten, sourceBuffer, read);
                    bytesWritten += (read * 2);
                }
            }
            // 3. Fill out with zeroes
            for (int n = bytesWritten; n < numBytes; n++)
                destBuffer[offset + n] = 0;
            position += numBytes;
            return numBytes;
        }

        /// <summary>
        /// Converts Mono to stereo, adjusting volume and pan
        /// </summary>
        private unsafe void MonoToStereo(byte[] destBuffer, int offset, byte[] sourceBuffer, int bytesRead)
        {
            fixed (byte* pDestBuffer = &destBuffer[offset],
                pSourceBuffer = &sourceBuffer[0])
            {
                float* pfDestBuffer = (float*)pDestBuffer;
                short* psSourceBuffer = (short*)pSourceBuffer;

                float leftVolume = (volume * (1 - pan) / 2.0f) / 32768f;
                float rightVolume = (volume * (pan + 1) / 2.0f) / 32768f;
                int samplesRead = bytesRead / 2;
                for (int n = 0; n < samplesRead; n++)
                {
                    pfDestBuffer[n * 2] = psSourceBuffer[n] * leftVolume;
                    pfDestBuffer[n * 2 + 1] = psSourceBuffer[n] * rightVolume;
                }
            }
        }

        /// <summary>
        /// Converts stereo to stereo
        /// </summary>
        private unsafe void AdjustVolume(byte[] destBuffer, int offset, byte[] sourceBuffer, int bytesRead)
        {
            fixed (byte* pDestBuffer = &destBuffer[offset],
                pSourceBuffer = &sourceBuffer[0])
            {
                float* pfDestBuffer = (float*)pDestBuffer;
                short* psSourceBuffer = (short*)pSourceBuffer;

                float leftVolume = (volume * (1 - pan) / 2.0f) / 32768f;
                float rightVolume = (volume * (pan + 1) / 2.0f) / 32768f;

                int samplesRead = bytesRead / 2;
                for (int n = 0; n < samplesRead; n += 2)
                {
                    pfDestBuffer[n] = psSourceBuffer[n] * leftVolume;
                    pfDestBuffer[n + 1] = psSourceBuffer[n + 1] * rightVolume;
                }
            }
        }

        /// <summary>
        /// <see cref="WaveStream.WaveFormat"/>
        /// </summary>
        public override WaveFormat WaveFormat
        {
            get
            {
                return waveFormat;
            }
        }

        /// <summary>
        /// Volume of this channel. 1.0 = full scale
        /// </summary>
        public float Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }

        /// <summary>
        /// Pan of this channel (from -1 to 1)
        /// </summary>
        public float Pan
        {
            get
            {
                return pan;
            }
            set
            {
                pan = value;
            }
        }

        /// <summary>
        /// Return false for has data if channel is muted
        /// </summary>
        public override bool HasData(int count)
        {
            // Check whether the source stream has data.
            bool sourceHasData = sourceStream.HasData(count);

            if (sourceHasData)
            {
                if (position + count < audioStartPosition)
                    return false;
                return (position < length) && (volume != 0);
            }
            return false;
        }

        /// <summary>
        /// Disposes this WaveStream
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (sourceStream != null)
                {
                    sourceStream.Dispose();
                    sourceStream = null;
                }
            }
            else
            {
                System.Diagnostics.Debug.Assert(false, "WaveChannel32 was not Disposed");
            }
            base.Dispose(disposing);
        }
    }
}
