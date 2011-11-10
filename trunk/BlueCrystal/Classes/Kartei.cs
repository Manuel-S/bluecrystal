using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BlueCrystal.Classes
{
    public class Kartei
    {
        public Kartei()
        {
            Vokabeln = new List<Vokabel>();
        }

        public List<Vokabel> Vokabeln
        {
            get;
            set;
        }

        public String Vorschau
        {
            get;
            set;
        }

        [XmlIgnore]
        public bool Selected
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Vorschau;
        }
    }
}
