using System;
using System.IO;
using System.Text;

namespace NAudio.Midi 
{
	/// <summary>
	/// Represents an individual MIDI event
	/// </summary>
	public class MidiEvent 
	{
		/// <summary>The MIDI command code</summary>
		private MidiCommandCode commandCode;
		private int channel;
		private int deltaTime;
		private long absoluteTime;
		
		/// <summary>
		/// Constructs a MidiEvent from a BinaryStream
		/// </summary>
		/// <param name="br">The binary stream of MIDI data</param>
		/// <param name="previous">The previous MIDI event (pass null for first event)</param>
		/// <returns>A new MidiEvent</returns>
		public static MidiEvent ReadNextEvent(BinaryReader br, MidiEvent previous) 
		{
			int deltaTime = MidiEvent.ReadVarInt(br);
			MidiCommandCode commandCode;
			int channel = 1;
			byte b = br.ReadByte();
			if((b & 0x80) == 0) 
			{
				// a running command - command & channel are same as previous
				commandCode = previous.CommandCode;
				channel = previous.Channel;
				br.BaseStream.Position--; // need to push this back
			}
			else 
			{
				if((b & 0xF0) == 0xF0) 
				{
                    // both bytes are used for command code in this case
					commandCode = (MidiCommandCode) b;
				}
				else 
				{
				    commandCode = (MidiCommandCode) (b & 0xF0);
				    channel = (b & 0x0F) + 1;
				}
			}
			
			MidiEvent me;
			switch(commandCode) 
			{
			case MidiCommandCode.NoteOn:
				me = new NoteOnEvent(br);
				break;					
			case MidiCommandCode.NoteOff:
			case MidiCommandCode.KeyAfterTouch:
				me = new NoteEvent(br);
				break;					
			case MidiCommandCode.ControlChange:
				me = new ControlChangeEvent(br);
				break;
			case MidiCommandCode.PatchChange:
				me = new PatchChangeEvent(br);
				break;
			case MidiCommandCode.ChannelAfterTouch:
				me = new ChannelAfterTouchEvent(br);
				break;
			case MidiCommandCode.PitchWheelChange:
				me = new PitchWheelChangeEvent(br);
				break;
			case MidiCommandCode.TimingClock:			
			case MidiCommandCode.StartSequence:
			case MidiCommandCode.ContinueSequence:
			case MidiCommandCode.StopSequence:
				me = new MidiEvent();
				break;
			case MidiCommandCode.Sysex:
				me = SysexEvent.ReadSysexEvent(br);
				break;
			case MidiCommandCode.MetaEvent:
				me = MetaEvent.ReadMetaEvent(br);
				break;
			default:
				throw new FormatException(String.Format("Unsupported MIDI Command Code {0:X2}",(byte) commandCode));
			}
			me.channel = channel;
			me.deltaTime = deltaTime;
			me.commandCode = commandCode;
			return me;
		}

        /// <summary>
        /// Default constructor
        /// </summary>
        protected MidiEvent()
        {
        }

        /// <summary>
        /// Creates a MIDI event with specified parameters
        /// </summary>
        /// <param name="absoluteTime">Absolute time of this event</param>
        /// <param name="channel">MIDI channel number</param>
        /// <param name="commandCode">MIDI command code</param>
        public MidiEvent(long absoluteTime, int channel, MidiCommandCode commandCode)
        {
            this.absoluteTime = absoluteTime;
            this.channel = channel;
            this.commandCode = commandCode;
        }

		/// <summary>
		/// The MIDI Channel Number for this event
		/// </summary>
		public int Channel 
		{
			get 
			{
				return channel;
			}
            set
            {
                if ((value < 1) || (value > 16))
                {
                    throw new ArgumentOutOfRangeException("Channel must be 1-16");
                }

                channel = value;
            }
		}
		
		/// <summary>
		/// The Delta time for this event
		/// </summary>
		public int DeltaTime 
		{
			get 
			{
				return deltaTime;
			}
		}
		
		/// <summary>
		/// The absolute time for this event
		/// </summary>
		public long AbsoluteTime 
		{
			get 
			{
				return absoluteTime;
			}
			set 
			{
				absoluteTime = value;
			}
		}
		
		/// <summary>
		/// The command code for this event
		/// </summary>
		public MidiCommandCode CommandCode 
		{
			get 
			{
				return commandCode;
			}
		}

        /// <summary>
        /// Whether this is a note off event
        /// </summary>
        public bool IsNoteOff
        {
            get
            {
                if (CommandCode == MidiCommandCode.NoteOn)
                {
                    NoteEvent ne = (NoteEvent) this;
                    return (ne.Velocity == 0);
                }
                return (CommandCode == MidiCommandCode.NoteOff);
            }
        }

        /// <summary>
        /// Determines if this is an end track event
        /// Perhaps make this a static member of the MetaEvent class
        /// </summary>
        public bool IsEndTrack
        {
            get
            {
                if (CommandCode == MidiCommandCode.MetaEvent)
                {
                    MetaEvent me = (MetaEvent)this;
                    return me.MetaEventType == MetaEventType.EndTrack;
                }
                return false;
            }
        }

		
		/// <summary>
		/// Displays a summary of the MIDI event
		/// </summary>
		/// <returns>A string containing a brief description of this MIDI event</returns>
		public override string ToString() 
		{
            if(commandCode >= MidiCommandCode.Sysex)
			    return String.Format("{0} {1}",absoluteTime,commandCode);
            else
                return String.Format("{0} {1} Ch: {2}", absoluteTime, commandCode, channel);
        }
		
		/// <summary>
		/// Utility function that can read a variable length integer from a binary stream
		/// </summary>
		/// <param name="br">The binary stream</param>
		/// <returns>The integer read</returns>
		public static int ReadVarInt(BinaryReader br) 
		{
			int value = 0;
			byte b;
			for(int n = 0; n < 4; n++) 
			{
				b = br.ReadByte();
				value <<= 7;
				value += (b & 0x7F);
				if((b & 0x80) == 0) 
				{
					return value;
				}
			}
			throw new FormatException("Invalid Var Int");
		}

        /// <summary>
        /// Writes a variable lenght integer to a binary stream
        /// </summary>
        /// <param name="writer">Binary stream</param>
        /// <param name="value">The value to write</param>
        public static void WriteVarInt(BinaryWriter writer, int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value", value.ToString(), "Cannot write a negative Var Int");
            }
            if (value > 0x0FFFFF)
            {                
                throw new ArgumentOutOfRangeException("value", value.ToString(), "Maximum allowed Var Int is 0x0FFFFFFF");
            }

            int n = 0;
            byte[] buffer = new byte[4];
            do
            {
                buffer[n++] = (byte)(value & 0x7F);
                value >>= 7;
            } while (value > 0);
            
            while (n > 0)
            {
                n--;
                if(n > 0)
                    writer.Write((byte) (buffer[n] | 0x80));
                else 
                    writer.Write(buffer[n]);
            }
        }

        /// <summary>
        /// Exports this MIDI event's data
        /// Overriden in derived classes, but they should call this version
        /// </summary>
        /// <param name="absoluteTime">Absolute time used to calculate delta. 
        /// Is updated ready for the next delta calculation</param>
        /// <param name="writer">Stream to write to</param>
        public virtual void Export(ref long absoluteTime, BinaryWriter writer)
        {
            if (this.absoluteTime < absoluteTime)
            {
                throw new FormatException("Can't export unsorted MIDI events");
            }
            WriteVarInt(writer,(int) (this.absoluteTime - absoluteTime));
            absoluteTime = this.absoluteTime;
            int output = (int) commandCode;
            if (commandCode != MidiCommandCode.MetaEvent)
            {
                output += (channel - 1);
            }
            writer.Write((byte)output);
        }
	}
}