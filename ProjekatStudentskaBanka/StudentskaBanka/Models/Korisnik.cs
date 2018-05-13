using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka.Models
{
    public class Korisnik
    {
        private String ime, prezime, jmbg, brTelefona, adresa, username, password;
        private bool uposlen;
        private Racun racun;


        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public string BrTelefona { get => brTelefona; set => brTelefona = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public bool Uposlen { get => uposlen; set => uposlen = value; }
        public Racun Racun { get => racun; set => racun = value; }

        public Korisnik()
        {
            ime = prezime = jmbg = brTelefona = adresa = username = password = null;
            Racun = null;
            uposlen = false;
        }

        public Korisnik(string ime, string prezime, string jmbg, string brTelefona, string adresa, string username, string password, bool uposlen)
        {
            Ime = ime;
            Prezime = prezime;
            Jmbg = jmbg;
            BrTelefona = brTelefona;
            Adresa = adresa;
            Username = username;
            Password = password;
            Uposlen = uposlen;
            Racun = new Racun();
        }

        public Korisnik(string ime, string prezime, string jmbg, string brTelefona, string adresa, string username, string password, bool uposlen, Racun racun)
        {
            Ime = ime;
            Prezime = prezime;
            Jmbg = jmbg;
            BrTelefona = brTelefona;
            Adresa = adresa;
            Username = username;
            Password = password;
            Uposlen = uposlen;
            Racun = racun;
        }
    }
}
