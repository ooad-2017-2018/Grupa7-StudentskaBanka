using StudentskaBanka.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentskaBanka.ViewModels
{
    public class MainPageViewModel
    {
        INavigationService NavigationService { get; set; }

        public ICommand PrijaviSe { get; set; }
        public ICommand RegistrujSe { get; set; }
        public ICommand OtvoriKonvertor { get; set; }

        public MainPageViewModel()
        {
            NavigationService = new NavigationService();
            PrijaviSe = new RelayCommand<object>(otvoriLoginView, returnTrue);
            RegistrujSe = new RelayCommand<object>(otvoriRegistracijaView, returnTrue);
            OtvoriKonvertor = new RelayCommand<object>(otvoriKonvertorValutaView, returnTrue);
        }

        #region PrijaviSe

        public void otvoriLoginView(object o)
        {
            //strana 25 na kerimovom dodatku pise ovo ispod : (treba vidjeti kakav parent treba, sta, zasto)
            //prebacuje na sljedeci view i proslijedjuje viewmodel za taj view, koji ima ovaj view (this) kao Parent            NavigationService.Navigate(typeof(Login));
        }

        #endregion PrijaviSe

        #region RegistrujSe
        public void otvoriRegistracijaView(object o)
        {
            //strana 25 na kerimovom dodatku pise ovo ispod : (treba vidjeti kakav parent treba, sta, zasto)
            //prebacuje na sljedeci view i proslijedjuje viewmodel za taj view, koji ima ovaj view (this) kao Parent
            NavigationService.Navigate(typeof(Registracija));
        }
        #endregion RegistrujSe

        #region OtvoriKonvertor
        public void otvoriKonvertorValutaView(object o)
        {
            //strana 25 na kerimovom dodatku pise ovo ispod : (treba vidjeti kakav parent treba, sta, zasto)
            //prebacuje na sljedeci view i proslijedjuje viewmodel za taj view, koji ima ovaj view (this) kao Parent
            NavigationService.Navigate(typeof(KonvertorValuta));
        }
        #endregion OtvoriKonvertor

        public bool returnTrue(object o)
        {
            return true;
        }

    }
}
