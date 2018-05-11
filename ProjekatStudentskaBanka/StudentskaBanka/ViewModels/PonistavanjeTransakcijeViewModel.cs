using StudentskaBanka.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentskaBanka.ViewModels
{
    public class PonistavanjeTransakcijeViewModel : BaseViewModel
    {
        BazaService baza;

        private int idTransakcije;
        public ICommand PonistiTransakciju { get; set; }
        public ICommand Nazad { get; set; }

        //TREBA NAPRAVITI KAD klikne Ponisti transakciju DA UZME ID TRANSAKCIJE I DA ODRADI PonistiTransakciju
        //gdje i kako izvrsiti provjeru ako je prazno polje idTransakcije ?
        public int IdTransakcije { get { return idTransakcije; } set { idTransakcije = value; OnPropertyChanged("IdTransakcije"); } }

        public PonistavanjeTransakcijeViewModel()
        {
            baza = new BazaService();
            PonistiTransakciju = new RelayCommand<object>(ponistiTransakciju, mogucePonistitiTransakciju);
            Nazad = new RelayCommand<object>(zatvoriPonistavanjeTransakcije, returnTrue);
        }

        #region PonistiTransakciju
        public void ponistiTransakciju(object o)
        {
            baza.ponistiTransakciju(idTransakcije);
        }

        public bool mogucePonistitiTransakciju(object o)
        {
            return baza.mogucePonistitiTransakciju(idTransakcije);
        }
        #endregion PonistiTransakciju

        #region Nazad
        public void zatvoriPonistavanjeTransakcije(object o)
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
