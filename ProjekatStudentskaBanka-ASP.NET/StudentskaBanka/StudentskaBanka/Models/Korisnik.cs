using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskaBanka.Models
{
    public class Korisnik
    {
        public int ID { get; set; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public String jmbg { get; set; }
        public String adresa { get; set; }
        public String brTelefona { get; set; }
        public String mail { get; set; }
        public String password { get; set; }
        public int racunId { get; set; }

        public Korisnik(int ID, string ime, string prezime, string jmbg, string adresa, string brTelefona, string mail, 
            string password, int racunId)
        {
            this.ID = ID;
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.adresa = adresa;
            this.brTelefona = brTelefona;
            this.mail = mail;
            this.password = password;
            this.racunId = racunId;
        }
    }
}