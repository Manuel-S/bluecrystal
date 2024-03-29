using System;

namespace NAudio.Midi 
{
	/// <summary>
	/// Represents a MIDI message
	/// </summary>
	public class MidiMessage 
	{
		private int rawData;

		/// <summary>
		/// Creates a new MIDI message
		/// </summary>
		/// <param name="status">Status</param>
		/// <param name="data1">Data parameter 1</param>
		/// <param name="data2">Data parameter 2</param>
		public MidiMessage(int status, int data1, int data2) 
		{
			rawData = status + (data1 << 8) + (data2 << 16);
		}
		
		/// <summary>
		/// Creates a Note On message
		/// </summary>
		/// <param name="note">Note number</param>
		/// <param name="volume">Volume</param>
		/// <param name="channel">MIDI channel</param>
		/// <returns>A new MidiMessage object</returns>
		public static MidiMessage StartNote(int note, int volume, int channel) 
		{
			return new MidiMessage((int) MidiCommandCode.NoteOn + channel,note,volume);
		}
		
		/// <summary>
		/// Creates a Note Off message
		/// </summary>
		/// <param name="note">Note number</param>
		/// <param name="volume">Volume</param>
		/// <param name="channel">MIDI channel</param>
		/// <returns>A new MidiMessage object</returns>
		public static MidiMessage StopNote(int note, int volume, int channel) 
		{
			return new MidiMessage((int) MidiCommandCode.NoteOff + channel,note,volume);
		}
		
		/// <summary>
		/// Creates a patch change message
		/// </summary>
		/// <param name="patch">The patch number</param>
		/// <param name="channel">The MIDI channel number</param>
		/// <returns>A new MidiMessageObject</returns>
		public static MidiMessage ChangePatch(int patch, int channel) 
		{
			return new MidiMessage((int) MidiCommandCode.PatchChange + channel,patch,0);
		}

		/// <summary>
		/// Returns the raw MIDI message data
		/// </summary>
		public int RawData 
		{
			get 
			{
				return rawData;
			}
		}
	}
}
