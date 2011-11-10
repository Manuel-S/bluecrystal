using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace NAudio.Midi 
{
	/// <summary>
	/// Class able to read a MIDI file
	/// </summary>
	public class MidiFile 
	{
		private List<List<MidiEvent>> events;
		private ushort fileFormat;
		private ushort tracks;
		private ushort deltaTicksPerQuarterNote;
        private bool strictChecking;

        /// <summary>
        /// Opens a MIDI file for reading
        /// </summary>
        /// <param name="filename">Name of MIDI file</param>
        public MidiFile(string filename)
            : this(filename,true)
        {
        }

        /// <summary>
        /// MIDI File format
        /// </summary>
        public int FileFormat
        {
            get { return fileFormat; }
        }

		/// <summary>
		/// Opens a MIDI file for reading
		/// </summary>
		/// <param name="filename">Name of MIDI file</param>
        /// <param name="strictChecking">If true will error on non-paired note events</param>
		public MidiFile(string filename, bool strictChecking)
        {
            this.strictChecking = strictChecking;
            
			BinaryReader br = new BinaryReader (File.OpenRead(filename));
			using(br) 
			{
				string chunkHeader = Encoding.ASCII.GetString(br.ReadBytes(4));
				if(chunkHeader != "MThd") 
				{
					throw new FormatException("Not a MIDI file - header chunk missing");
				}
				uint chunkSize = Swap(br.ReadUInt32());
				
				if(chunkSize != 6) 
				{
                    throw new FormatException("Unexpected header chunk length");
				}
				fileFormat = Swap(br.ReadUInt16());
				// 0 = single track, 1 = multi-track synchronous, 2 = multi-track asynchronous
				tracks = Swap(br.ReadUInt16());
				deltaTicksPerQuarterNote = Swap(br.ReadUInt16());
				events = new List<List<MidiEvent>>();
				long absoluteTime = 0;
				
				for(int track = 0; track < tracks; track++) 
				{
                    events.Add(new List<MidiEvent>());

                    if(fileFormat == 1) 
					{
						absoluteTime = 0;
					}
					chunkHeader = Encoding.ASCII.GetString(br.ReadBytes(4));
					if(chunkHeader != "MTrk") 
					{
                        throw new FormatException("Invalid chunk header");
					}
					chunkSize = Swap(br.ReadUInt32());

					long startPos = br.BaseStream.Position;
					MidiEvent me = null;
                    List<NoteOnEvent> outstandingNoteOns = new List<NoteOnEvent>();
                    while(br.BaseStream.Position < startPos + chunkSize) 
					{
                        
						me = MidiEvent.ReadNextEvent(br,me);
						absoluteTime += me.DeltaTime;
						me.AbsoluteTime = absoluteTime;
                        events[track].Add(me);
						if(me.CommandCode == MidiCommandCode.NoteOn) 
						{
							NoteEvent ne = (NoteEvent) me;
							if(ne.Velocity > 0) 
							{
								outstandingNoteOns.Add((NoteOnEvent) ne);
							}
							else 
							{
                                // don't remove the note offs, even though
                                // they are annoying
                                // events[track].Remove(me);
								FindNoteOn(ne,outstandingNoteOns);
							}
						}
						else if(me.CommandCode == MidiCommandCode.NoteOff) 
						{
							FindNoteOn((NoteEvent) me,outstandingNoteOns);
						}
						else if(me.CommandCode == MidiCommandCode.MetaEvent) 
						{
							MetaEvent metaEvent = (MetaEvent) me;
							if(metaEvent.MetaEventType == MetaEventType.EndTrack) 
							{
								//break;
                                // some dodgy MIDI files have an event after end track
                                if (strictChecking)
                                {
                                    if (br.BaseStream.Position < startPos + chunkSize)
                                    {
                                        throw new FormatException(String.Format("End Track event was not the last MIDI event on track {0}", track));
                                    }
                                }
							}
						}
					}
					if(outstandingNoteOns.Count > 0) 
					{
                        if (strictChecking)
                        {
                            throw new FormatException(String.Format("Note ons without note offs {0} (file format {1})", outstandingNoteOns.Count, fileFormat));
                        }
					}
					if(br.BaseStream.Position != startPos + chunkSize) 
					{
                        throw new FormatException(String.Format("Read too far {0}+{1}!={2}", chunkSize, startPos, br.BaseStream.Position));
					}
				}
			}
		}

        /// <summary>
        /// A full list of the events on this track
        /// </summary>
        public List<MidiEvent> GetTrackEvents(int track)
        {
            return events[track];
        }

        /// <summary>
        /// Number of tracks in this MIDI file
        /// </summary>
        public int Tracks
        {
            get { return tracks; }
        }

        /// <summary>
        /// Delta Ticks Per Quarter Note
        /// </summary>
        public int DeltaTicksPerQuarterNote
        {
            get { return deltaTicksPerQuarterNote; }
        }

        private void FindNoteOn(NoteEvent offEvent, List<NoteOnEvent> outstandingNoteOns)
		{
			bool found = false;
			foreach(NoteOnEvent noteOnEvent in outstandingNoteOns) 
			{
				if ((noteOnEvent.Channel == offEvent.Channel) && (noteOnEvent.NoteNumber == offEvent.NoteNumber)) 
				{
                    noteOnEvent.OffEvent = offEvent;
					outstandingNoteOns.Remove(noteOnEvent);
					found = true;
					break;
				}
			}
			if(!found) 
			{
                if (strictChecking)
                {
                    throw new FormatException(String.Format("Got an off without an on {0}", offEvent));
                }
			}
		}
		
		private static uint Swap(uint i) 
		{
			return ((i & 0xFF000000) >> 24) | ((i & 0x00FF0000) >> 8) | ((i & 0x0000FF00) << 8) | ((i & 0x000000FF) << 24);
		}

		private static ushort Swap(ushort i) 
		{
			return (ushort) (((i & 0xFF00) >> 8) | ((i & 0x00FF) << 8));
		}
		
		/// <summary>
		/// Describes the MIDI file
		/// </summary>
		/// <returns>A string describing the MIDI file and its events</returns>
		public override string ToString() 
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("Format {0}, Tracks {1}, Delta Ticks Per Quarter Note {2}\r\n",
				fileFormat,tracks,deltaTicksPerQuarterNote);
            for (int n = 0; n < tracks; n++)
            {
                foreach (MidiEvent midiEvent in events[n])
                {
                    sb.AppendFormat("{0}\r\n", midiEvent);
                }
            }
			return sb.ToString();
		}

        /// <summary>
        /// Exports a MIDI file
        /// </summary>
        public static void Export(string filename, long startAbsoluteTime, int midiFileType, int deltaTicksPerQuarterNote, List<List<MidiEvent>> events)
        {
            if (midiFileType == 0 && events.Count > 1)
            {
                throw new ArgumentException("Can't export more than one track to a type 0 file");
            }
            using (BinaryWriter writer = new BinaryWriter(File.Create(filename)))
            {
                writer.Write(Encoding.ASCII.GetBytes("MThd"));
                writer.Write(Swap((uint)6));
                writer.Write(Swap((ushort)midiFileType));
                writer.Write(Swap((ushort)events.Count));
                writer.Write(Swap((ushort)deltaTicksPerQuarterNote));

                foreach (List<MidiEvent> eventList in events)
                {
                    writer.Write(Encoding.ASCII.GetBytes("MTrk"));
                    long trackSizePosition = writer.BaseStream.Position;
                    writer.Write(Swap((uint)0));

                    long absoluteTime = startAbsoluteTime;

                    eventList.Sort(new MidiEventComparer());                    
                    if (eventList.Count > 0)
                    {
                        System.Diagnostics.Debug.Assert(eventList[eventList.Count - 1].IsEndTrack, "Exporting a track with a missing end track");
                    }
                    foreach (MidiEvent midiEvent in eventList)
                    {
                        midiEvent.Export(ref absoluteTime, writer);
                    }

                    uint trackChunkLength = (uint)(writer.BaseStream.Position - trackSizePosition) - 4;
                    writer.BaseStream.Position = trackSizePosition;
                    writer.Write(Swap(trackChunkLength));
                    writer.BaseStream.Position += trackChunkLength;
                }
            }
        }
	}
	
    /// <summary>
    /// Utility class for comparing MidiEvent objects
    /// </summary>
    public class MidiEventComparer : IComparer<MidiEvent>
    {
        #region IComparer<MidiEvent> Members

        /// <summary>
        /// Compares two MidiEvents
        /// Sorts by time, with EndTrack always sorted to the end
        /// </summary>
        public int Compare(MidiEvent x, MidiEvent y)
        {
            long xTime = x.AbsoluteTime;
            long yTime = y.AbsoluteTime;

            if (xTime == yTime)
            {
                // sort meta events before note events, except end track
                MetaEvent xMeta = x as MetaEvent;
                MetaEvent yMeta = y as MetaEvent;

                if (xMeta != null)
                {
                    if (xMeta.MetaEventType == MetaEventType.EndTrack)
                        xTime = Int64.MaxValue;
                    else
                        xTime = Int64.MinValue;
                }
                if (yMeta != null)
                {
                    if (yMeta.MetaEventType == MetaEventType.EndTrack)
                        yTime = Int64.MaxValue;
                    else
                        yTime = Int64.MinValue;
                }
            }
            return xTime.CompareTo(yTime);
        }

        #endregion
    }
}