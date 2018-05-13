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
    public class PonistavanjeTransakcijeViewModel : BaseViewModel
    {
        private NavigationService ns;
        private int idTransakcije;
        public ICommand PonistiTransakciju { get; set; }
        public ICommand Nazad { get; set; }

        public NavigationService Ns { get => ns; set => ns = value; }


        //TREBA NAPRAVITI KAD klikne Ponisti transakciju DA UZME ID TRANSAKCIJE I DA ODRADI PonistiTransakciju
        //gdje i kako izvrsiti provjeru ako je prazno polje idTransakcije ?
        public int IdTransakcije { get { return idTransakcije; } set { idTransakcije = value; OnPropertyChanged("IdTransakcije"); } }


        public PonistavanjeTransakcijeViewModel(NavigationService ns)
        {
            Ns = ns;
            PonistiTransakciju = new RelayCommand<object>(ponistiTransakciju);
            Nazad = new RelayCommand<object>(zatvoriPonistavanjeTransakcije, returnTrue);
        }

        #region PonistiTransakciju
        public async void ponistiTransakciju(object o)
        {
            if(await (Baza.mogucePonistitiTransakciju(idTransakcije)) == false)
            {
                MessageDialog poruka = new MessageDialog("Nije moguće poništiti transakciju!");
                await poruka.ShowAsync();
                return;
            }
            Baza.ponistiTransakciju(idTransakcije);
        }
        #endregion PonistiTransakciju

        #region Nazad
        public void zatvoriPonistavanjeTransakcije(object o)
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
