using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskaBanka.Models
{
    public class Racun
    {
        public int ID { get; set; }
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