using System;
using System.Collections.Generic;

namespace BlueCrystal.Classes
{
    public class Vokabel
    {
        public Vokabel()
        {
            Sprachen = new List<List<TeilVokabel>>();
        }

        public List<List<TeilVokabel>> Sprachen
        {
            get;
            set;
        }

        public String Bemerkung
        {
            get;
            set;
        }
            
    }
}
