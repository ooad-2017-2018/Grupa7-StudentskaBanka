using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskaBanka.Models
{
    public class Kredit
    {
        public int ID { get; set; }
        public int ukupnoUzeto { get; set; }
        public int ukupnoZaVratiti { get; set; }
        public int kamata { get; set; }
        public int racunId { get; set; }

        public Kredit(int ID, int ukupnoUzeto, int ukupnoZaVratiti, int kamata, int racunId)
        {
            this.ID = ID;
            this.ukupnoUzeto = ukupnoUzeto;
            this.ukupnoZaVratiti = ukupnoZaVratiti;
            this.kamata = kamata;
            this.racunId = racunId;
        }
    }
}