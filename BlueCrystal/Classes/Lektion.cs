using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Settings.Xml;

namespace BlueCrystal.Classes
{
    public class Lektion : AppSettings
    {
        public List<String> Sprachen { get; set; }
        public List<Kartei> Karteien { get; set; }

        public Lektion(FileSystemInfo file)
        {
            this.Load(file.FullName);
        }

        public Lektion()
        {
            Sprachen = new List<string>();
            Karteien = new List<Kartei>();
            NichtAkzeptierteSprachen = new List<List<int>>();
        }

        public List<List<int>> NichtAkzeptierteSprachen
        {
            get;
            set;
        }

        public void Save(String path)
        {
            base.SaveAppSettings(path);
        }

        public String Name
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
