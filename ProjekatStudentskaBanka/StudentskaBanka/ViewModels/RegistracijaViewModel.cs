using StudentskaBanka.AzureDatabase;
using StudentskaBanka.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace StudentskaBanka.ViewModels
{
    public class RegistracijaViewModel : BaseViewModel
    {
        private NavigationService ns;
        private String ime, prezime, jmbg, adresa, brojTelefona, email, sifra, ponoviteSifru;
        private bool kvadraticCekiran;
        private bool uposlenik;

        public ICommand Registruj { get; set; }
        public ICommand Nazad { get; set; }

        public string Ime { get { return ime; } set { ime = value; OnPropertyChanged("Ime"); } }
        public string Prezime { get { return prezime; } set { prezime = value; OnPropertyChanged("Prezime"); } }
        public string Jmbg { get => jmbg; set { jmbg = value; OnPropertyChanged("Jmbg"); } }
        public string Adresa { get => adresa; set { adresa = value; OnPropertyChanged("Adresa"); } }
        public string BrojTelefona { get => brojTelefona; set { brojTelefona = value; OnPropertyChanged("BrojTelefona"); } }
        public string Email { get => email; set { email = value; OnPropertyChanged("Email"); } }
        public string Sifra { get => sifra; set { sifra = value; OnPropertyChanged("Sifra"); } }
        public string PonoviteSifru { get => ponoviteSifru; set { ponoviteSifru = value; OnPropertyChanged("PonoviteSifru"); } }
        public bool KvadraticCekiran { get { if (kvadraticCekiran) return true; return false; } set { kvadraticCekiran = value; OnPropertyChanged("KvadraticCekiran"); } }
        public bool Uposlenik { get { if (uposlenik) return true; return false; } set { uposlenik = value; OnPropertyChanged("Uposlenik");} }
        public NavigationService Ns { get => ns; set => ns = value; }


       
        public RegistracijaViewModel(NavigationService ns)
        {
            Ns = ns;
            Registruj = new RelayCommand<object>(registrujKorisnika);
            Nazad = new RelayCommand<object>(zatvoriRegistracijaView, returnTrue);
            kvadraticCekiran = uposlenik = false;
        }

        #region Registruj
        public async void registrujKorisnika(object o)
        {
            MessageDialog poruka;

            if (ime == null || prezime == null || jmbg == null || adresa == null || brojTelefona == null || email == null || sifra == null)
            {
                poruka = new MessageDialog("Molimo vas da popunite sve podatke!");
                await poruka.ShowAsync();
                return;
            }
            else if (!kvadraticCekiran)
            {
                poruka = new MessageDialog("Molimo vas da cekirate kvadratic!");
                await poruka.ShowAsync();
                return;
            }
            else if (!sifra.Equals(PonoviteSifru))
            {
                poruka = new MessageDialog("Sifre moraju biti jednake!");
                await poruka.ShowAsync();
                return;
            }

            Baza.dodajKorisnika(ime, prezime, jmbg, brojTelefona, adresa, email, sifra, uposlenik);
            poruka = new MessageDialog("Uspješno ste obavili registraciju!");
            await poruka.ShowAsync();
            return;
        }
        #endregion Registruj
        
        #region Nazad
        public void zatvoriRegistracijaView(object o)
        {
            ns.GoBack();
        }

        #endregion Nazad

        public bool returnTrue(object o)
        {
            return true;
        }

    }
}
