using StudentskaBanka.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentskaBanka.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        BazaService bazaPodataka;
        private String username;
        private String password;

        public ICommand PrijaviSe { get; set; }
        public ICommand Nazad { get; set; }

        //Ovo bi trebalo da osigura kada se promijeni tekst u tekstboxu da se promijeni text i ovdje(username i password)
        //Nigdje nisam nista bindao jos uvijek, treba vidjeti kako to ide
        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }
        

        public LoginViewModel()
        {
            bazaPodataka = new BazaService();
            PrijaviSe = new RelayCommand<object>(otvoriProfilKlijentaView, postojiLiKorisnik);
            Nazad = new RelayCommand<object>(zatvoriLoginViewModel, returnTrue);
        }

    
        #region PrijaviSe
        public void otvoriProfilKlijentaView(object o)
        {
            //strana 25 na kerimovom dodatku pise ovo ispod : (treba vidjeti kakav parent treba, sta, zasto)
            //prebacuje na sljedeci view i proslijedjuje viewmodel za taj view, koji ima ovaj view (this) kao Parent
            //NavigationService.Navigate(typeof(ProfilKlijenta));
        }

        public bool postojiLiKorisnik(object o)
        {
            return bazaPodataka.postojiLiUsernamePassword(username, password);
        }
        #endregion PrijaviSe

        #region Nazad
        public void zatvoriLoginViewModel(object o)
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
