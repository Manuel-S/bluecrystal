using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NAudio.Wave;

namespace BlueCrystal.Classes
{
    public static class AudioHelper
    {
        //Declarations required for audio out and mixing
        private static IWavePlayer waveOutDevice;
        private static WaveMixerStream32 mixer;

        // The Sample array we will load our Audio Samples in to
        private static AudioSample Sample;

        // WaveIn Streams for recording
        static WaveInStream waveInStream;
        static WaveFileWriter writer;

        public static void Play(string file)
        {
            mixer = new WaveMixerStream32 { AutoStop = true };

            if (waveOutDevice == null)
            {
                waveOutDevice = new WaveOut(0, 300, null);

                waveOutDevice.Init(mixer);
                waveOutDevice.Play();
            }
            if (Sample != null)
            {
                Sample.Close();
            }
            Sample = new AudioSample(file);
            waveOutDevice.Dispose();
            mixer.AddInputStream(Sample);
            waveOutDevice.Init(mixer);
            waveOutDevice.Play();
        }

        public static void StartRecord(string file)
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
            }
            if (Sample != null)
            {
                Sample.Close();
            }
            waveInStream = new WaveInStream(0, new WaveFormat(), null);
            writer = new WaveFileWriter(file, waveInStream.WaveFormat);
            waveInStream.DataAvailable += new EventHandler<WaveInEventArgs>(waveInStream_DataAvailable);
            waveInStream.StartRecording();
        }

        public static void StopRecord()
        {
            waveInStream.StopRecording();
            waveInStream.Dispose();
            waveInStream = null;
            writer.Flush();
            writer.Close();
            writer.Dispose();
            writer = null;
        }

        static void waveInStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            writer.WriteData(e.Buffer, 0, e.BytesRecorded);
        }
    }
}
