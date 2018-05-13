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
    public class ProfilKlijentaViewModel
    {
        private Korisnik k;
        private NavigationService ns;

        //Kad bude se binding radio treba poksuat bindat one textboxe za K.Ime jer su oba propertija i trbealo bi moci
        public Korisnik K { get => k; set => k = value; }
        public NavigationService Ns { get => ns; set => ns = value; }

        private ICommand NovaTransakcija { get; set; }
        private ICommand PonistiTransakciju { get; set; }
        private ICommand Nazad { get; set; }
        private ICommand RegistrujNovog { get; set; }

        public ProfilKlijentaViewModel(ObjectKorisnikNavigationService obj)
        {
            this.k = obj.K;
            this.ns = obj.Ns;
            NovaTransakcija = new RelayCommand<object>(novaTransakciju, pravoPristupa);
            PonistiTransakciju = new RelayCommand<object>(ponistiTransakciju, pravoPristupa);
            Nazad = new RelayCommand<object>(nazad, returnTrue);
            RegistrujNovog = new RelayCommand<object>(registrujNovog, returnTrue);
        }

        public void registrujNovog(object obj)
        {
            Ns.Navigate(typeof(Registracija), ns);
        }

        public void novaTransakciju(object o)
        {
            Ns.Navigate(typeof(NovaTransakcija), ns);
        }

        public void ponistiTransakciju(object o)
        {
            Ns.Navigate(typeof(PonistavanjeTransakcije), ns);
        }

        private void nazad(object obj)
        {
            ns.GoBack();
        }
        

        private bool returnTrue(object arg)
        {
            return true; ;
        }

        public bool pravoPristupa(object o)
        {
            return k.Uposlen;
        }


    }
}
