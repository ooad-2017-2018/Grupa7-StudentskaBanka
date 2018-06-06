using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentskaBanka.Models
{
    public class Racun
    {
        public int ID { get; set; }
        [Range(-500,10000, ErrorMessage = "Dug ne može biti veći od 500")]
        public int stanje { get; set; }
        public bool blokiran { get; set; }

        public Racun(int ID, int stanje, bool blokiran)
        {
            this.ID = ID;
            this.stanje = stanje;
            this.blokiran = blokiran;
        }
    }
}