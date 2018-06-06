using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentskaBanka.Models
{
    public class Korisnik
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Ime")]
        public String ime { get; set; }

        [Required]
        [Display(Name = "Prezime")]
        public String prezime { get; set; }

        [Display(Name = "Matični broj")]
        public String jmbg { get; set; }
        [Display(Name = "Adresa")]
        public String adresa { get; set; }
        [Display(Name = "Broj telefona")]
        public String brTelefona { get; set; }
        [Display(Name = "Email")]
        public String mail { get; set; }
        [Display(Name = "Password")]
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