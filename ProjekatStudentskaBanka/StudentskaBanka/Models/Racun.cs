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
        private List<Transakcija> obavljeneTransakcije;
        private bool blokiran;
        private List<Kredit> listaKredita;

        public Korisnik Korisnik { get => korisnik; set => korisnik = value; }
        public float Stanje { get => stanje; set => stanje = value; }
        public List<Transakcija> ObavljeneTransakcije { get => obavljeneTransakcije; set => obavljeneTransakcije = value; }
        public bool Blokiran { get => blokiran; set => blokiran = value; }
        public List<Kredit> ListaKredita { get => listaKredita; set => listaKredita = value; }

        public Racun(Korisnik korisnik, float stanje, List<Transakcija> obavljeneTransakcije, List<Kredit> listaKredita)
        {
            Korisnik = korisnik;
            Stanje = stanje;
            obavljeneTransakcije = new List<Transakcija>();
            Blokiran = false;
            listaKredita = new List<Kredit>();
        }
    }
}
