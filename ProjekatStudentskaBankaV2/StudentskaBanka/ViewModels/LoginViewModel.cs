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
    public class LoginViewModel
    {
        public String username;
        public String password;
        public String ime, prezime, brojTelefona, adresa, jmbg, ponoviSifru;
        public bool uposlen; //po defaultu false
        public StudentskaBanka.Models.StudentskaBanka banka;
        public Korisnik k;
        public bool kvadratic; // po defaultu false

        INavigationService INS { get; set; }

        ICommand Login { get; set; }
        ICommand Registracija { get; set; }
        ICommand Konvertor { get; set; }
        ICommand Povratak { get; set; }
        ICommand RegistrujNovogKorisnika { get; set; }
        
        public LoginViewModel()
        {
            banka = new Models.StudentskaBanka();

            Login = new RelayCommand<object>(prebaciNaProfilKlijentaView, potvrdi);
            Registracija = new RelayCommand<object>(prebaciNaRegistracijaView);
            Konvertor = new RelayCommand<object>(prebaciNaKonvertorView);
            Povratak = new RelayCommand<object>(povratak);
        }
        
        public bool potvrdi(Object o)
        {
            //MODERATOR = GlavniBABA
            if (banka.GlavniBABA.Username == username && banka.GlavniBABA.Password == password)
            {
                return true;
            }
            //Ostali korisnici
            else if (banka.ListaKorisnika.Exists(x => x.Username == username && x.Password == password))
            {
                return true;
            }
            return false;
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
        
        public void prebaciNaProfilKlijentaView(Object o)
        {
            INS.Navigate(typeof(StudentskaBanka.ProfilKlijenta));
        }

        public void prebaciNaRegistracijaView(Object o)
        {
            INS.Navigate(typeof(StudentskaBanka.Registracija));
        }

        public void prebaciNaLoginView(Object o)
        {
            INS.Navigate(typeof(StudentskaBanka.Login));
        }

        public void prebaciNaKonvertorView(Object o)
        {
            INS.Navigate(typeof(StudentskaBanka.KonvertorValuta));
        }

        public void povratak(Object o)
        {
            INS.GoBack();
        }
    }
}
