using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
    /// <summary>
    /// Interop definitions for Windows ACM (Audio Compression Manager) API
    /// </summary>
    class AcmInterop
    {
        public delegate bool AcmDriverEnumCallback(int hAcmDriverId, int instance, AcmDriverDetailsSupportFlags flags);

        [DllImport("Msacm32.dll")]
        public static extern MmResult acmDriverClose(IntPtr hAcmDriver, int closeFlags);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmDriverEnum(AcmDriverEnumCallback fnCallback, int dwInstance, AcmDriverEnumFlags flags);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmDriverDetails(int hAcmDriver, ref AcmDriverDetails driverDetails, int reserved);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmDriverOpen(out IntPtr pAcmDriver, int hAcmDriverId, int openFlags);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmMetrics(IntPtr hAcmObject, AcmMetrics metric, out int output);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmFormatSuggest(IntPtr hAcmDriver, WaveFormat sourceFormat, WaveFormat destFormat, int sizeDestFormat, AcmFormatSuggestFlags suggestFlags);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmStreamOpen(out IntPtr hAcmStream, IntPtr hAcmDriver, WaveFormat sourceFormat, WaveFormat destFormat, WaveFilter waveFilter, int callback, int instance, AcmStreamOpenFlags openFlags);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmStreamClose(IntPtr hAcmStream, int closeFlags);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmStreamConvert(IntPtr hAcmStream, [In, Out] AcmStreamHeaderStruct streamHeader, AcmStreamConvertFlags streamConvertFlags);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmStreamPrepareHeader(IntPtr hAcmStream, [In, Out] AcmStreamHeaderStruct streamHeader, int prepareFlags);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmStreamReset(IntPtr hAcmStream, int resetFlags);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmStreamSize(IntPtr hAcmStream, int inputBufferSize, out int outputBufferSize, AcmStreamSizeFlags flags);
        [DllImport("Msacm32.dll")]
        public static extern MmResult acmStreamUnprepareHeader(IntPtr hAcmStream, [In, Out] AcmStreamHeaderStruct streamHeader, int flags);

    }
}
