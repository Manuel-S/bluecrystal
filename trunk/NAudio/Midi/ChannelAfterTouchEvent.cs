using System;
using System.IO;

namespace NAudio.Midi
{
	/// <summary>
	/// Represents a MIDI Channel AfterTouch Event.
	/// </summary>
	public class ChannelAfterTouchEvent : MidiEvent 
	{
        private byte afterTouchPressure;
		/// <summary>
		/// Creates a new ChannelAfterTouchEvent from raw MIDI data
		/// </summary>
		/// <param name="br">A binary reader</param>
		public ChannelAfterTouchEvent(BinaryReader br) 
		{
			afterTouchPressure = br.ReadByte();
            if ((afterTouchPressure & 0x80) != 0) 
			{
                // TODO: might be a follow-on				
                throw new FormatException("Invalid afterTouchPressure");
			}
		}

        /// <summary>
        /// Calls base class export first, then exports the data 
        /// specific to this event
        /// <seealso cref="MidiEvent.Export">MidiEvent.Export</seealso>
        /// </summary>
        public override void Export(ref long absoluteTime, BinaryWriter writer)
        {
            base.Export(ref absoluteTime, writer);
            writer.Write(afterTouchPressure);
        }

        /// <summary>
        /// The aftertouch pressure value
        /// </summary>
        public int AfterTouchPressure
        {
            get
            {
                return afterTouchPressure;
            }
            set
            {
                if (value < 0 || value > 127)
                {
                    throw new ArgumentOutOfRangeException("After touch pressure must be in the range 0-127");
                }
                afterTouchPressure = (byte)value;
            }
        }

	}
}
