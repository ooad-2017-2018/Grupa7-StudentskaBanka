using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using StudentskaBanka.Models;

namespace StudentskaBanka.AzureDatabase
{
    public class Baza
    {
        //GURU ZA BAZE

        //Id korisnika treba da bude i id racuna jer 1 korisnik = 1 racun.
        //Malo je promijenjen model, pogledaj opet klasu racun i korisnik
        //korisnik ima atribut racun kod sebe a racun nema id nego koristi korisnikov. 
        //ovo omogucuje da se lako spoje ove 2 tabele preko foreign keya u bazi

        //Striktno uraditi sta je napisano u funkcijama i nista vise
        //Ne trebaju nikakve provjere, sve je provjereno tamo
        
        //TREBA MI U BAZI jedan insan, neka ima id 1, neka je to neki racun banke 
        //On mi treba da bih mogao omoguciti da se uplati na neki racun iako covjek koji uplacuje nema racun.

        

        public Baza()
        {

        }

        public static async Task<bool> postojiLiUsernamePassword(String Username, String Password)
        {
            //ako u bazi ne postoji ova kombinacija username-a i password-a, daj mi false
            IMobileServiceTable<korisnici> Korisnici = App.MobileService.GetTable<korisnici>();

            IEnumerable<korisnici> tabela = await Korisnici.ReadAsync();

            foreach(var element in tabela)
            {
                if (element.username.Equals(Username) && element.password.Equals(Password))
                    return true;
            }

            return false;
        }

        public static async Task<bool> moguceIzvrsitiTransakciju(int posiljalac, int primalac, float iznos)
        {
            if(posiljalac == 1) return true; //(PS, zbog ovog mi treba onaj insan sa id=1 sto sam ga gore opisao)

            //ako posiljalac ima stanjeRacuna < iznos vratiti false

            IMobileServiceTable<korisnici> Korisnici = App.MobileService.GetTable<korisnici>();
            IMobileServiceTable<racuni> Racuni = App.MobileService.GetTable<racuni>();

            IEnumerable<korisnici> tabelaK = await Korisnici.ReadAsync();
            IEnumerable<racuni> tabelaR = await Racuni.ReadAsync();

            //provjera da li uopste postoje posiljalac i primalac u bazi
            bool postojiPosiljalac = false;
            bool postojiPrimalac = false;
            foreach (var pos in tabelaK)
                if (pos.ID.Equals(posiljalac))
                {
                    postojiPosiljalac = true;
                    break;
                }
            foreach (var prim in tabelaK)
                if (prim.ID.Equals(primalac))
                {
                    postojiPrimalac = true;
                    break;
                }

            //ako ne postoje transakcija se naravno ne moze izvrsiti
            if (!postojiPrimalac || !postojiPosiljalac)
                return false;



            //ovo je ustvari povezivanje preko foreign keya - korisnici.racun_id i racuni.ID

            foreach (var elementK in tabelaK)
                if(elementK.ID.Equals(posiljalac))
                    foreach(var elementR in tabelaR)
                    {
                        if(elementK.racun_id.Equals(elementR.ID))
                        {
                            if (elementR.stanje < iznos)
                                return false;
                        }
                            
                    }
            

            return true;
        }

        public void izvrsiTransakciju(int posiljalac, int primalac, float iznos)
        {
            /*
            if (posiljalac == 1)
            //Na racun primaoca staviti iznos
            else 
                //Na racun primaoca staviti iznos
                //Sa racuna posiljaoca skinuti iznos
            */

            IMobileServiceTable<korisnici> Korisnici = App.MobileService.GetTable<korisnici>();
            IMobileServiceTable<racuni> Racuni = App.MobileService.GetTable<racuni>();

            bool moguce = false;

            IEnumerable<korisnici> tabelaK = await Korisnici.ReadAsync();
            IEnumerable<racuni> tabelaR = await Racuni.ReadAsync();

            // nije gotovo
        }

        public void ponistiTransakciju(int idTransakcije)
        {
            //imas id transakcije, mozes naci racun primaoca i posiljaoca i iznost
            //sa racuna primaoca skinuti iznos (naravno da se moze ici u minus)
            //na racun posiljaoca staviti iznos
        }

        public bool mogucePonistitiTransakciju(int idTransakcije)
        {
            //ako se nalazi transakcija u bazi = return true
            //mozes dodati ogranicenje ako je starija od 3 dana, il sta na taj fazon al ne moras se peglat
            //ako budes htio pripazi presjek sa prvim uslovom

            return false;
        }

        public void registrujKorisnika(String ime, String prezime, String jmbg, String adresa, String brojTelefona, String email, String sifra, bool uposlenik)
        {
            //sve jasno bi trebalo biti
            //pripazi na taj ID korisnika, PRVI u bazi mi mora biti neki nas domacin, admin admin admin admin, nek su mu svi atributi admin i id = 1

        }

    }
}
