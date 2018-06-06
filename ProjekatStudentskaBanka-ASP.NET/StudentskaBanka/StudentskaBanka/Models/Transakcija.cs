using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskaBanka.Models
{
    public class Transakcija
    {
        public int ID { get; set; }
        public int posiljalacId { get; set; }
        public int primalacId { get; set; }
        public DateTime vrijeme { get; set; }
        public int iznos { get; set; }

        public Transakcija(int ID, int posiljalacId, int primalacId, DateTime vrijeme, int iznos)
        {
            this.ID = ID;
            this.posiljalacId = posiljalacId;
            this.primalacId = primalacId;
            this.vrijeme = vrijeme;
            this.iznos = iznos;
        }
    }
}