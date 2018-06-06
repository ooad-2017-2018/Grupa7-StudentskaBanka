using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentskaBanka.Models
{
    public class Kredit
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Range(500,5000, ErrorMessage = "Kredit ne može biti manji od 500 ili veći od 5000")]
        public int ukupnoUzeto { get; set; }

        public int ukupnoZaVratiti { get; set; }
        public decimal kamata { get; set; }
        public int racunId { get; set; }

        public Kredit() { }

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