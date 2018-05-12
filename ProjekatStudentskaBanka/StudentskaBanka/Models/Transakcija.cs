using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka.Models
{
    public class Transakcija
    {
        private int id;
        private Racun primalac;
        private Racun posiljalac;
        private DateTime vrijeme;
        private float iznos;

        public int Id { get => id; set => id = value; }
        public Racun Primalac { get => primalac; set => primalac = value; }
        public Racun Posiljalac { get => posiljalac; set => posiljalac = value; }
        public DateTime Vrijeme { get => vrijeme; set => vrijeme = value; }
        public float Iznos { get => iznos; set => iznos = value; }

        static int globalId = 1;

        public Transakcija(Racun primalac, Racun posiljalac, DateTime vrijeme, int iznos)
        {
            Id = globalId;
            globalId += 1;
            Primalac = primalac;
            Posiljalac = posiljalac;
            Vrijeme = vrijeme;
            Iznos = iznos;
        }
    }
}
