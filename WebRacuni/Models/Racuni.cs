using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRacuni.Models
{
    public class Racuni
    {
        public Dictionary<string, Racun> collection { get; set; }
        public List<string> tipovi { get; set; }

        public Racuni()
        {
            collection = new Dictionary<string, Racun>();
            tipovi = new List<string>();
            tipovi.Add("Dinarski");
            tipovi.Add("Devizni");
        }

        public Racuni(Dictionary<string, Racun> collection)
        {
            this.collection = collection;
            tipovi = new List<string>();
            tipovi.Add("Dinarski");
            tipovi.Add("Devizni");
        }

        public void AddTip(string s)
        {
            tipovi.Add(s);
        }
    }
}