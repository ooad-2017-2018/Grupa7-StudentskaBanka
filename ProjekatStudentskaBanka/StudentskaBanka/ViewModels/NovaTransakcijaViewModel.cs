using StudentskaBanka.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentskaBanka.ViewModels
{
    public class NovaTransakcijaViewModel : BaseViewModel
    {
        BazaService baza;
        private bool prebacivanje;
        private int posiljalac;
        private int primalac;
        private float iznos;

        public ICommand IzvrsiTransakciju { get; set; }
        public ICommand Nazad { get; set; }

        //Nista nije bindano

        public int Posiljalac { get { return posiljalac; } set { posiljalac = value; OnPropertyChanged("Posiljalac"); } }
        public int Primalac { get { return primalac; } set { primalac = value; OnPropertyChanged("Primalac"); } }
        public float Iznos { get { return iznos; } set { iznos = value; OnPropertyChanged("Iznos"); } }


        //Treba mi 
        //TREBA MI NEGDJE DA PROVJERIM AKO JE SELEKTOVANO Uplata na racun
        //odnosno ako je prebacivanje = false;
        //da postavim posiljalac = 1, kako to da uradim?

        public NovaTransakcijaViewModel()
        {
            baza = new BazaService();
            IzvrsiTransakciju = new RelayCommand<object>(izvrsiTransakciju, moguceIzvrsitiTransakciju);
            Nazad = new RelayCommand<object>(zatvoriLoginViewModel, returnTrue);
        }

        #region IzvrsiTransakciju
        public void izvrsiTransakciju(object o)
        {
            baza.izvrsiTransakciju(posiljalac, primalac, iznos);
        }

        public bool moguceIzvrsitiTransakciju(object o)
        {
            return baza.moguceIzvrsitiTransakciju(posiljalac, primalac, iznos);
        }
        #endregion IzvrsiTransakciju

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
