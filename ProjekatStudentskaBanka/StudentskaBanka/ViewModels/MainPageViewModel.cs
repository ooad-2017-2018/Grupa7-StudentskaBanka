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
        NavigationService NavigationService { get; set; }

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
            NavigationService.Navigate(typeof(Login), NavigationService);
        }

        #endregion PrijaviSe

        #region RegistrujSe
        public void otvoriRegistracijaView(object o)
        {
            NavigationService.Navigate(typeof(Registracija), NavigationService);
        }
        #endregion RegistrujSe

        //Konvertor nije sredjen
        #region OtvoriKonvertor
        public void otvoriKonvertorValutaView(object o)
        {
            NavigationService.Navigate(typeof(KonvertorValuta));
        }
        #endregion OtvoriKonvertor

        public bool returnTrue(object o)
        {
            return true;
        }

    }
}
