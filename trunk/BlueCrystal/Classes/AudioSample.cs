/* 
 * This code was origionaly written by Mark Heath - MixDiffStream.cs; contained in the MixDiffDemo application from NAudio. 
 * The following code is licenced under the MS-PL.
 * 
 * Additional modifications writen by Sebastian Gray.
*/

using System;
using NAudio.Wave;

namespace BlueCrystal.Classes
{
    public class AudioSample : WaveStream
    {
        // General Sample Settings (Info)
        string _fileName = "";
        bool _loop;
        long _pausePosition = -1;
        bool _pauseLoop;

        // Sample WaveStream Settings
        //WaveOffsetStream offsetStream;
        WaveChannel32 channelStream;
        bool muted;
        float volume;
        private WaveFileReader reader;

        public AudioSample(string fileName)
        {
            _fileName = fileName;
            reader = new WaveFileReader(fileName);
            //offsetStream = new WaveOffsetStream(reader);
            //channelStream = new WaveChannel32(offsetStream);
            channelStream = new WaveChannel32(reader, 1.0f, 0, new TimeSpan(0));
            
            muted = false;
        }

        public override void Close()
        {
            base.Close();
            channelStream.Close();
            reader.Close();
        }



        public override WaveFormat WaveFormat
        {
            get { return channelStream.WaveFormat; }
        }

        public override long Length
        {
            get { return channelStream.Length; }
        }

        public override long Position
        {
            get
            {
                return channelStream.Position;
            }
            set
            {
                channelStream.Position = value;
            }
        }



        public override int Read(byte[] buffer, int offset, int count)
        {
            return channelStream.Read(buffer, offset, count);
        }









        #region NotUsed


        public bool Mute
        {
            get
            {
                return muted;
            }
            set
            {
                muted = value;
                if (muted)
                {
                    channelStream.Volume = 0.0f;
                }
                else
                {
                    // reset the volume                
                    Volume = Volume;
                }
            }
        }


        public override bool HasData(int count)
        {
            return channelStream.HasData(count);
        }

        public float Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
                if (!Mute)
                {
                    channelStream.Volume = volume;
                }
            }
        }

        // We are not using the delay stream..
        //public TimeSpan PreDelay
        //{
        //    get { return offsetStream.StartTime; }
        //    set { offsetStream.StartTime = value; }
        //}

        //public TimeSpan Offset
        //{
        //    get { return offsetStream.SourceOffset; }
        //    set { offsetStream.SourceOffset = value; }
        //}

        protected override void Dispose(bool disposing)
        {
            if (channelStream != null)
            {
                channelStream.Dispose();
            }

            base.Dispose(disposing);
        }

        public override int BlockAlign
        {
            get
            {
                return channelStream.BlockAlign;
            }
        }


        // General Sample Settings (Info)

        /// <summary>
        /// FileName of the loaded sample
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
        }

        /// <summary>
        /// Loop determines wether the sample will play in a loop - takes imediate effect and cna be turned on and off while a sample is playing.
        /// </summary>
        public void SetLoop(bool Loop)
        {
            _loop = Loop;
        }

        public void Pause()
        {
            // Store the current stream settings
            _pausePosition = Position;
            _pauseLoop = _loop;

            // Ensure the sample is temporairly not looped and set the position to the end of the stream
            _loop = false;
            Position = Length;

            // Set the loop status back, so that any further modifications of the loop status are observed
            _loop = _pauseLoop;
        }

        public void Resume()
        {
            // Ensure that the sample had actuall been paused and that we are not just jumping to a random position
            if (_pausePosition >= 0)
            {
                // Set the position of the stream back to where it was paused
                Position = _pausePosition;

                // Set the pause position to negative so that we know the sample is not currently paused
                _pausePosition = -1;
            }
        }

        public void SetPan(float pan)
        {
            channelStream.Pan = pan;
        }


        #endregion


    }
}
