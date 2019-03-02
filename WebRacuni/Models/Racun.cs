using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRacuni.Models
{
    public class Racun
    {
        public string brojRacuna { get; set; }
        public string tipRacuna { get; set; }
        public double raspolozivoStanje { get; set; }
        public double rezervisanoStanje { get; set; }
        public double ukupnoStanje { get; set; }
        public bool aktivan { get; set; }

        public Racun() { }

        public Racun(string brojRacuna, string tipRacuna, double raspolozivoStanje, double rezervisanoStanje, bool aktivan)
        {
            this.brojRacuna = brojRacuna;
            this.tipRacuna = tipRacuna;
            this.raspolozivoStanje = raspolozivoStanje;
            this.rezervisanoStanje = rezervisanoStanje;
            this.ukupnoStanje = raspolozivoStanje + rezervisanoStanje;
            this.aktivan = aktivan;
        }
    }
}