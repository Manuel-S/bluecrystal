using System;
using System.Runtime.InteropServices;
using NAudio.Wave;

namespace NAudio.Midi 
{
	internal class MidiInterop 
	{
		public const int MAXPNAMELEN = 32; 				// max product name length (including NULL)
		public const int MIDICAPS_VOLUME = 0x0001; 		// supports volume control
		public const int MIDICAPS_LRVOLUME = 0x0002; 	// separate left-right volume control
		public const int MIDICAPS_CACHE = 0x0004;
		public const int MIDICAPS_STREAM = 0x0008; 		// driver supports midiStreamOut directly

		[DllImport("winmm.dll")]
		public static extern MmResult midiConnect(int hmi,int hmo,int pReserved);

		[DllImport("winmm.dll")]
		public static extern MmResult midiDisconnect(int hmi,int hmo,int pReserved);

		[DllImport("winmm.dll")]
		public static extern MmResult midiInAddBuffer(int hMidiIn,[MarshalAs(UnmanagedType.Struct)] ref MIDIHDR lpMidiInHdr,int uSize);

		[DllImport("winmm.dll")]
		public static extern MmResult midiInClose(int hMidiIn);

		[DllImport("winmm.dll")]
		public static extern MmResult midiInGetDevCaps(int uDeviceID,[MarshalAs(UnmanagedType.Struct)] ref MIDIINCAPS lpCaps,int uSize);

		[DllImport("winmm.dll")]
		public static extern MmResult midiInGetErrorText(int err,string lpText,int uSize);

		[DllImport("winmm.dll")]
		public static extern MmResult midiInGetID(int hMidiIn,int lpuDeviceID);

		[DllImport("winmm.dll")]
		public static extern int midiInGetNumDevs();

		[DllImport("winmm.dll")]
		public static extern MmResult midiInMessage(int hMidiIn,int msg,int dw1,int dw2);

		[DllImport("winmm.dll")]
		public static extern MmResult midiInOpen(ref int lphMidiIn,int uDeviceID,int dwCallback,int dwInstance,int dwFlags);

		[DllImport("winmm.dll")]
		public static extern MmResult midiInPrepareHeader(int hMidiIn,[MarshalAs(UnmanagedType.Struct)] ref MIDIHDR lpMidiInHdr,int uSize);

		[DllImport("winmm.dll")]
		public static extern MmResult midiInReset(int hMidiIn);

		[DllImport("winmm.dll")]
		public static extern MmResult midiInStart(int hMidiIn);

		[DllImport("winmm.dll")]
		public static extern MmResult midiInStop(int hMidiIn);

		[DllImport("winmm.dll")]
		public static extern MmResult midiInUnprepareHeader(int hMidiIn,[MarshalAs(UnmanagedType.Struct)] ref MIDIHDR lpMidiInHdr,int uSize);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutCacheDrumPatches(int hMidiOut,int uPatch,int lpKeyArray,int uFlags);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutCachePatches(int hMidiOut,int uBank,int lpPatchArray,int uFlags);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutClose(int hMidiOut);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutGetDevCaps(int uDeviceID,[MarshalAs(UnmanagedType.Struct)] ref MIDIOUTCAPS lpCaps,int uSize);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutGetErrorText(int err,string lpText,int uSize);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutGetID(int hMidiOut,int lpuDeviceID);

		[DllImport("winmm.dll")]
		public static extern int midiOutGetNumDevs();

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutGetVolume(int uDeviceID,ref int lpdwVolume);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutLongMsg(int hMidiOut,[MarshalAs(UnmanagedType.Struct)] ref MIDIHDR lpMidiOutHdr,int uSize);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutMessage(int hMidiOut,int msg,int dw1,int dw2);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutOpen(int lphMidiOut,int uDeviceID,int dwCallback,int dwInstance,int dwFlags);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutPrepareHeader(int hMidiOut,[MarshalAs(UnmanagedType.Struct)] ref MIDIHDR lpMidiOutHdr,int uSize);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutReset(int hMidiOut);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutSetVolume(int uDeviceID,int dwVolume);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutShortMsg(int hMidiOut,int dwMsg);

		[DllImport("winmm.dll")]
		public static extern MmResult midiOutUnprepareHeader(int hMidiOut,[MarshalAs(UnmanagedType.Struct)] ref MIDIHDR lpMidiOutHdr,int uSize);

		[DllImport("winmm.dll")]
		public static extern MmResult midiStreamClose(int hms);

		[DllImport("winmm.dll")]
		public static extern MmResult midiStreamOpen(int phms,int puDeviceID,int cMidi,int dwCallback,int dwInstance,int fdwOpen);

		[DllImport("winmm.dll")]
		public static extern MmResult midiStreamOut(int hms,[MarshalAs(UnmanagedType.Struct)] ref MIDIHDR pmh,int cbmh);

		[DllImport("winmm.dll")]
		public static extern MmResult midiStreamPause(int hms);

		[DllImport("winmm.dll")]
		public static extern MmResult midiStreamPosition(int hms,[MarshalAs(UnmanagedType.Struct)] ref MMTIME lpmmt,int cbmmt);

		[DllImport("winmm.dll")]
		public static extern MmResult midiStreamProperty(int hms,byte lppropdata,int dwProperty);

		[DllImport("winmm.dll")]
		public static extern MmResult midiStreamRestart(int hms);

		[DllImport("winmm.dll")]
		public static extern MmResult midiStreamStop(int hms);
		
		// TODO: this is general MM interop
		public const int CALLBACK_FUNCTION = 0x30000;
		public const int CALLBACK_NULL = 0;
		
		[StructLayout(LayoutKind.Sequential)] 
		public struct MMTIME 
		{
			public int wType;
			public int u;
		}
		
		// TODO: check for ANSI strings in these structs
		// TODO: check for WORD params
		[StructLayout(LayoutKind.Sequential)] 
		public struct MIDIEVENT
		{
			public int  dwDeltaTime;
			public int  dwStreamID;
			public int  dwEvent;
			[MarshalAs(UnmanagedType.ByValArray,SizeConst=1)]
			public int  dwParms;
		}

		[StructLayout(LayoutKind.Sequential)] 
		public struct MIDIHDR 
		{
			public string  lpData;
			public int  dwBufferLength;
			public int  dwBytesRecorded;
			public int  dwUser;
			public int  dwFlags;
			public int  lpNext;
			public int  Reserved;
		}

		[StructLayout(LayoutKind.Sequential)] 
		public struct MIDIINCAPS 
		{
			public int  wMid;
			public int  wPid;
			public int  vDriverVersion;
			[MarshalAs(UnmanagedType.ByValTStr,SizeConst=MAXPNAMELEN)]
			public string  szPname;
		}

		[StructLayout(LayoutKind.Sequential)] 
		public struct MIDIOUTCAPS 
		{
			public UInt16 wMid;
			public Int16 wPid;
			public int  vDriverVersion;
			[MarshalAs(UnmanagedType.ByValTStr,SizeConst=MAXPNAMELEN)]
			public string szPname;
			public UInt16 wTechnology;
			public UInt16 wVoices;
			public UInt16 wNotes;
			public UInt16 wChannelMask;
			public UInt32 dwSupport;
		}

		[StructLayout(LayoutKind.Sequential)] 
		public struct MIDIPROPTEMPO 
		{
			public int  cbStruct;
			public int  dwTempo;
		}

		
	}
}
