using StudentskaBanka.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentskaBanka.ViewModels
{
    public class RegistracijaViewModel : BaseViewModel
    {
        BazaService baza;
        private String ime, prezime, jmbg, adresa, brojTelefona, email, sifra, ponoviteSifru;
        private bool kvadraticCekiran;
        private bool uposlenik;

        public ICommand Registruj { get; set; } 
        public ICommand Nazad { get; set; }

        public string Ime { get {return ime; } set { ime = value; OnPropertyChanged("Ime"); } }
        public string Prezime { get {return prezime; } set { prezime = value; OnPropertyChanged("Prezime"); } }
        public string Jmbg { get => jmbg; set { jmbg = value; OnPropertyChanged("Jmbg"); } }
        public string Adresa { get => adresa; set { adresa = value; OnPropertyChanged("Adresa"); } }
        public string BrojTelefona { get => brojTelefona; set { brojTelefona = value; OnPropertyChanged("BrojTelefona"); } }
        public string Email { get => email; set { email = value; OnPropertyChanged("Email"); } }
        public string Sifra { get => sifra; set { sifra = value; OnPropertyChanged("Sifra"); } }
        public string PonoviteSifru { get => ponoviteSifru; set { PonoviteSifru = value; OnPropertyChanged("PonoviteSifru"); } }

        //KAKO ZNATI KOJI JE SELEKTOVAN KVADRATIC KOJI NIJE I JE LI SELEKTOVAN UOPSTE

        public RegistracijaViewModel()
        {
            baza = new BazaService();
            Registruj = new RelayCommand<object>(registrujKorisnika, moguceRegistrovatiKorisnika);
            Nazad = new RelayCommand<object>(zatvoriRegistracijaView, returnTrue);
        }

        #region Registruj
        public void registrujKorisnika(object o)
        {
            baza.registrujKorisnika(ime, prezime, jmbg, adresa, brojTelefona, email, sifra, uposlenik);
        }
        public bool moguceRegistrovatiKorisnika(object o)
        {
            //milion validacija odradit
            return true;
        }
        #endregion Registruj
        
        #region Nazad
        public void zatvoriRegistracijaView(object o)
        {
            //NavigationService.GoBack();  //ili nesto tako, ima neka fja
        }

        #endregion Nazad

        public bool returnTrue(object o)
        {
            return true;
        }

    }
}
