using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentskaBanka.Models
{
    public class Racun
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Range(-500,10000, ErrorMessage = "Dug ne može biti veći od 500")]
        public int stanje { get; set; }
         
        public bool blokiran { get; set; }

        public Racun() { }

        public Racun(int stanje, bool blokiran)
        {
            this.stanje = stanje;
            this.blokiran = blokiran;
        }
    }
}