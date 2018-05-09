using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka.Models
{
    public class StudentskaBanka
    {
        private List<Korisnik> listaKorisnika;
        private List<Racun> listaRacuna;
        private List<Transakcija> listaTransakcija;
        private List<Kredit> listaKredita;

        public StudentskaBanka()
        {
            listaKorisnika = new List<Korisnik>();
            listaRacuna = new List<Racun>();
            listaTransakcija = new List<Transakcija>();
            listaKredita = new List<Kredit>();
        }

        public List<Korisnik> ListaKorisnika { get => listaKorisnika; set => listaKorisnika = value; }
        public List<Racun> ListaRacuna { get => listaRacuna; set => listaRacuna = value; }
        public List<Transakcija> ListaTransakcija { get => listaTransakcija; set => listaTransakcija = value; }
        public List<Kredit> ListaKredita { get => listaKredita; set => listaKredita = value; }
    }
}
