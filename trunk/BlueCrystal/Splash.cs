using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlueCrystal
{
    public static class Splash
    {
        private static SplashForm splash;

        private static void DoSplash()
        {
            splash = new SplashForm();
            splash.ShowDialog();
        }

        public static void SetMessage(string message)
        {
            while (splash == null || !splash.Initialized)
            {

            }
            splash.setMessage(message);
        }

        private static Thread splashThread;

        public static void Open()
        {
            splashThread = new Thread(DoSplash);
            splashThread.Start();
        }

        public static void Close()
        {
            splash.Close();
            Thread.Sleep(1000);
            splashThread.Abort();
        }
    }
}
