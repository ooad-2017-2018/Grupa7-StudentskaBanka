using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka.Models
{
    public class Racun
    {
        private Korisnik korisnik;
        private float stanje;
        private bool blokiran;

        public Korisnik Korisnik { get => korisnik; set => korisnik = value; }
        public float Stanje { get => stanje; set => stanje = value; }
        public bool Blokiran { get => blokiran; set => blokiran = value; }
        
        public Racun(Korisnik korisnik)
        {
            Korisnik = korisnik;
            Stanje = 0;
            Blokiran = false;
        }
    }
}
