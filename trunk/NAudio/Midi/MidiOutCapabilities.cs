using System;

namespace NAudio.Midi 
{
	/// <summary>
	/// class representing the capabilities of a MIDI out device
	/// </summary>
	public class MidiOutCapabilities 
	{
		
		private MidiInterop.MIDIOUTCAPS caps;
		
		internal MidiOutCapabilities(MidiInterop.MIDIOUTCAPS caps) 
		{
			this.caps = caps;		
		}
		
		/// <summary>
		/// Gets the manufacturer of this device
		/// </summary>
		public Manufacturers Manufacturer
		{
			get 
			{
				return (Manufacturers) caps.wMid;
			}
		}
		
		/// <summary>
		/// Gets the product identifier (manufacturer specific)
		/// </summary>
		public short ProductId 
		{
			get 
			{
				return caps.wPid;
			}
		}
		
		/// <summary>
		/// Gets the product name
		/// </summary>
		public String ProductName 
		{
			get 
			{
				return caps.szPname;
			}
		}

		/// <summary>
		/// Returns the number of supported voices
		/// </summary>
		public int Voices 
		{
			get 
			{
				return caps.wVoices;
			}
		}
		
		/// <summary>
		/// Gets the polyphony of the device
		/// </summary>
		public int Notes 
		{ 
			get 
			{
				return caps.wNotes;
			}
		}
		
		/// <summary>
		/// Returns true if the device supports all channels
		/// </summary>
		public bool SupportsAllChannels 
		{
			get 
			{
				return caps.wChannelMask == 0xFFFF;
			}
		}
		
		/// <summary>
		/// Queries whether a particular channel is supported
		/// </summary>
		/// <param name="channel">Channel number to test</param>
		/// <returns>True if the channel is supported</returns>
		public bool SupportsChannel(int channel) 
		{
			return (caps.wChannelMask & (1 << (channel - 1))) > 0;
		}
		
		/// <summary>
		/// Returns true if the device supports patch caching
		/// </summary>
		public bool SupportsPatchCaching 
		{
			get 
			{
				return (caps.dwSupport & MidiInterop.MIDICAPS_CACHE) != 0;
			}
		}

		/// <summary>
		/// Returns true if the device supports separate left and right volume
		/// </summary>
		public bool SupportsSeparateLeftAndRightVolume 
		{
			get 
			{
				return (caps.dwSupport & MidiInterop.MIDICAPS_LRVOLUME) != 0;
			}
		}

		/// <summary>
		/// Returns true if the device supports MIDI stream out
		/// </summary>
		public bool SupportsMidiStreamOut 
		{
			get 
			{
				return (caps.dwSupport & MidiInterop.MIDICAPS_STREAM) != 0;
			}
		}

		/// <summary>
		/// Returns true if the device supports volume control
		/// </summary>
		public bool SupportsVolumeControl 
		{
			get 
			{
				return (caps.dwSupport & MidiInterop.MIDICAPS_VOLUME) != 0;
			}
		}
 
		/// <summary>
		/// Returns the type of technology used by this MIDI out device
		/// </summary>
		public MidiOutTechnology Technology 
		{
			get 
			{
				return (MidiOutTechnology) caps.wTechnology;
			}
		}
	
	}
}
