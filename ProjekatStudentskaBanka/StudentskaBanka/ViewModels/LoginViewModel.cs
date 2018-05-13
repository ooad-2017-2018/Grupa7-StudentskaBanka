using StudentskaBanka.AzureDatabase;
using StudentskaBanka.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.IO;
using Windows.UI.Popups;

namespace StudentskaBanka.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private String username;
        private String password;
        private NavigationService ns;

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

        public NavigationService Ns { get { return ns; } set => ns = value; }

        public LoginViewModel(NavigationService navigationService)
        {
            PrijaviSe = new RelayCommand<object>(otvoriProfilKlijentaView);
            Nazad = new RelayCommand<object>(zatvoriLoginViewModel, returnTrue);
            Ns = navigationService;
        }
        
        #region PrijaviSe
        public async void otvoriProfilKlijentaView(object o)
        {
            if(await (Baza.postojiLiUsernamePassword(username, password)) == false)
            {
                MessageDialog poruka = new MessageDialog("Pogrešni pristupni podaci!");
                await poruka.ShowAsync();
                return;
            }

            ns.Navigate(typeof(ProfilKlijenta), new ObjectKorisnikNavigationService(ns, await Baza.dajKorisnika(username, password)));
        }

        #endregion PrijaviSe

        #region Nazad
        public void zatvoriLoginViewModel(object o)
        {
            Ns.GoBack();
        }

        #endregion Nazad

        public bool returnTrue(object o)
        {
            return true;
        }

    }
}
