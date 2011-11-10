using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace BlueCrystal.Classes
{
    public class Profil
    {
        public Profil(String name)
        {
            ProfilName = name;
            String profiles = (String)Registry.GetValue(@"HKEY_CURRENT_USER\Software\BlueCrystal", "ProfileNames", String.Empty);
            if (profiles == null)
            {
                profiles = String.Empty;
            }
            List<String> profile = new List<String>();
            profile.AddRange(profiles.Split(';'));
            if (!profile.Contains(name))
            {
                profile.Add(name);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\BlueCrystal", "ProfileNames", String.Join(";", profile.ToArray()));
            }
            
        }

        public String ProfilName
        {
            get;
            private set;
        }

        public String Statistik
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override String ToString()
        {
            return ProfilName;
        }
    }
}
