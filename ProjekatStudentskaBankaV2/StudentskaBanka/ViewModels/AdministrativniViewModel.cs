using StudentskaBanka.Helper;
using StudentskaBanka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentskaBanka.ViewModels
{
    class AdministrativniViewModel
    {
        public String username;
        public String password;
        public String ime, prezime, brojTelefona, adresa, jmbg, ponoviSifru;
        public bool uposlen; //po defaultu false
        public Korisnik k;
        public bool kvadratic; // po defaultu false

        public String racunPosiljaoca;
        public String racunPrimaoca;
        
        ICommand RegistrujNovogKorisnika { get; set; }
        ICommand NovaTransakcija { get; set; }

        public AdministrativniViewModel()
        {
            RegistrujNovogKorisnika = new RelayCommand<object>(registrujNovogKorisnika, provjeriPodatke);
            NovaTransakcija = new RelayCommand<object>(izvrsiTransakciju, moguceIzvrsitiTransakciju);
        }

        public void izvrsiTransakciju(Object o)
        {
            //ili dodaj na racun 
        }

        public bool moguceIzvrsitiTransakciju(Object o)
        {
            //Ako je true onda je obicna transakcija
            //Ako je false onda je sa racuna na racun
            if (kvadratic)
            {
                if (racunPrimaoca.Trim().Equals(""))
                    return false;
                //AKO U BANCI NE POSTOJI TAJ RACUN ONDA TREBA FALSE
                //ako je blokiran racun na koji se salje onda treba false
            }
            else
            {
                if (racunPrimaoca.Trim().Equals("") || racunPosiljaoca.Trim().Equals(""))
                    return false;
                //else if ( ne postoji racun posiljaoca || ne postoji racun primaoca )

                //else if (racun primaoca blokiran || racun posiljaoca blokiran)
                
                //else if (racun posiljaoca nema dovoljno sredstava)

            }
            return true;
        }



        public void registrujNovogKorisnika(Object o)
        {
            k = new Korisnik(ime, prezime, jmbg, brojTelefona, adresa, username, password, uposlen);
            banka.ListaKorisnika.Add(k);
            banka.ListaRacuna.Add(new Racun(k));
        }

        public bool provjeriPodatke(Object o)
        {
            if (ime.Trim().Equals("") || prezime.Trim().Equals("") || brojTelefona.Trim().Equals("") ||
                adresa.Trim().Equals("") || jmbg.Trim().Equals("") || ponoviSifru.Trim().Equals("") ||
                username.Trim().Equals("") || password.Trim().Equals(""))
                return false;
            else if (username.Length < 5 || banka.ListaKorisnika.Exists(x => x.Username == username))
                return false;
            else if (!password.Equals(ponoviSifru) || password.Length < 5)
                return false;
            //provjera jmbg, broj telefona etc
            return true;
        }
    }
}
