using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka.Helper
{
    public class BazaService
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

        public BazaService()
        {

        }

        public bool postojiLiUsernamePassword(String username, String password)
        {
            //ako u bazi ne postoji ova kombinacija username-a i password-a, daj mi false
            return true;
        }

        public bool moguceIzvrsitiTransakciju(int posiljalac, int primalac, float iznos)
        {
            if(posiljalac == 1) return true; //(PS, zbog ovog mi treba onaj insan sa id=1 sto sam ga gore opisao)
            //nastavlja se provjera..
            {
                //IF posiljalac ima stanjeRacuna < iznos
                return false;
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
