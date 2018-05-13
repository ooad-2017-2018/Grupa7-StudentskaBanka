using StudentskaBanka.AzureDatabase;
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
        private NavigationService ns;
        private int posiljalac;
        private int primalac;
        private float iznos;

        public ICommand IzvrsiTransakciju { get; set; }
        public ICommand Nazad { get; set; }


        //Nista nije bindano

        public NavigationService Ns { get => ns; set => ns = value; }
        public int Posiljalac { get { return posiljalac; } set { posiljalac = value; OnPropertyChanged("Posiljalac"); } }
        public int Primalac { get { return primalac; } set { primalac = value; OnPropertyChanged("Primalac"); } }
        public float Iznos { get { return iznos; } set { iznos = value; OnPropertyChanged("Iznos"); } }
        
        public NovaTransakcijaViewModel(NavigationService ns)
        {
            ns = ns;
            //kad tek udje na novaTransakcija mora biti selektovano prebaci sa racuna na racun
            IzvrsiTransakciju = new RelayCommand<object>(izvrsiTransakciju, moguceIzvrsitiTransakciju);
            Nazad = new RelayCommand<object>(zatvoriNovaTransakcijaView, returnTrue);
        }

        #region IzvrsiTransakciju
        public void izvrsiTransakciju(object o)
        {
            Baza.izvrsiTransakciju(posiljalac, primalac, iznos);
        }

        public bool moguceIzvrsitiTransakciju(object o)
        {
            //ako je string, ako nije int vracaj false - ove
            //provjeriti i posiljaoca i primaoca i iznos
            return Baza.moguceIzvrsitiTransakciju(posiljalac, primalac, iznos);
        }
        #endregion IzvrsiTransakciju

        #region Nazad
        public void zatvoriNovaTransakcijaView(object o)
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
