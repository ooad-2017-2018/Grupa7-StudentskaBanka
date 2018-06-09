using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using StudentskaBanka.Models;
using Windows.UI.Popups;

namespace StudentskaBanka.AzureDatabase
{
    public class Baza
    {

        private static bool provjeriDaLiJeDatumStarijiOd3Dana(DateTime datum)
        {
            if ((DateTime.Now - datum).TotalDays > 3)
                return false;
            return true;
        }
        

        public Baza()
        {

        }

        public static async Task<bool> postojiLiUsernamePassword(String Username, String Password)
        {
            //ako u bazi ne postoji ova kombinacija username-a i password-a, vraca false
            IMobileServiceTable<korisnici> Korisnici = App.MobileService.GetTable<korisnici>();

            IEnumerable<korisnici> tabela = await Korisnici.ReadAsync();

            foreach(var element in tabela)
            {
                if (element.username.Equals(Username) && element.password.Equals(Password))
                    return true;
            }

            return false;
        }
        
        public static async Task<Korisnik> dajKorisnika(string username, string password)
        {
            try
            {
                IMobileServiceTable<korisnici> Korisnici = App.MobileService.GetTable<korisnici>();

                IEnumerable<korisnici> tabela = await Korisnici.ReadAsync();

                foreach (var element in tabela)
                {
                    if (element.username.Equals(username) && element.password.Equals(password))
                    {
                        Racun racun = new Racun();
                        IMobileServiceTable<racuni> Racuni = App.MobileService.GetTable<racuni>();

                        IEnumerable<racuni> tabelaR = await Racuni.ReadAsync();

                        foreach (var elementR in tabelaR)
                            if (elementR.ID.Equals(element.racun_id))
                            {
                                racun.Stanje = elementR.stanje;
                                racun.Blokiran = elementR.blokiran;
                            }

                        return new Korisnik(element.ime, element.prezime, element.jmbg, element.brojTelefona, element.adresa, element.username,
                            element.password, element.uposlen, racun);
                    }

                }
            }
            catch(Exception e)
            {
                throw;
            }

            
            return new Korisnik(); // nece se nikada izvrsiti
           
            
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

        public static async void izvrsiTransakciju(int posiljalac, int primalac, float iznos)
        {

            IMobileServiceTable<korisnici> Korisnici = App.MobileService.GetTable<korisnici>();
            IMobileServiceTable<racuni> Racuni = App.MobileService.GetTable<racuni>();

            IEnumerable<korisnici> tabelaK = await Korisnici.ReadAsync();
            IEnumerable<racuni> tabelaR = await Racuni.ReadAsync();

            foreach (var elementK in tabelaK)
            {
                if (elementK.ID.Equals(posiljalac))
                    foreach (var elementR in tabelaR)
                    {
                        if (elementK.racun_id.Equals(elementR.ID))
                        {
                            elementR.stanje -= iznos;
                            Racuni.UpdateAsync(elementR);
                        }

                    }
                if(elementK.ID.Equals(primalac))
                    foreach (var elementR in tabelaR)
                    {
                        if (elementK.racun_id.Equals(elementR.ID))
                        {
                            elementR.stanje += iznos;
                            Racuni.UpdateAsync(elementR);
                        }

                    }
            }

        }

        public static async void ponistiTransakciju(int idTransakcije)
        {
            //imas id transakcije, mozes naci racun primaoca i posiljaoca i iznost
            //sa racuna primaoca skinuti iznos (naravno da se moze ici u minus)
            //na racun posiljaoca staviti iznos
            
        }

        public static async Task<bool> mogucePonistitiTransakciju(int idTransakcije)
        {
            //ako se nalazi transakcija u bazi = return true
            //mozes dodati ogranicenje ako je starija od 3 dana, il sta na taj fazon al ne moras se peglat
            //ako budes htio pripazi presjek sa prvim uslovom

            IMobileServiceTable<transakcije> Transakcije = App.MobileService.GetTable<transakcije>();
            IEnumerable<transakcije> tabelaT = await Transakcije.ReadAsync();

            bool postoji = false;
            foreach(var elementT in tabelaT)
            {
                //provjerava se da li uopste postoji 
                if (elementT.ID.Equals(idTransakcije))

                    //ako postoji provjeri se da li je starija od 3 dana, funkcija provjeriDatum je iznad u kodu
                    if(provjeriDaLiJeDatumStarijiOd3Dana(elementT.vrijeme))
                    {
                        return true;
                        break;
                    }
            }

            return false;
        }

        public static async void dodajKorisnika(string ime, string prezime, string jmbg, string brTelefona, string adresa, string username, string password, bool uposlen)
        {
            IMobileServiceTable<korisnici> Korisnici = App.MobileService.GetTable<korisnici>();

            korisnici korisnik = new korisnici();
            korisnik.ime = ime;
            korisnik.prezime = prezime;
            korisnik.jmbg = jmbg;
            korisnik.brojTelefona = brTelefona;
            korisnik.adresa = adresa;
            korisnik.username = username;
            korisnik.password = password;
            korisnik.uposlen = uposlen;

            try
            {
                await Korisnici.InsertAsync(korisnik);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public static async void dodajTransakciju(transakcije transakcija)
        {
            IMobileServiceTable<transakcije> Transakcije = App.MobileService.GetTable<transakcije>();

            try
            {
                await Transakcije.InsertAsync(transakcija);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async void dodajKredit(krediti kredit)
        {
            IMobileServiceTable<krediti> Krediti = App.MobileService.GetTable<krediti>();

            try
            {
                await Krediti.InsertAsync(kredit);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async void dodajRacun(racuni racun)
        {
            IMobileServiceTable<racuni> Racuni = App.MobileService.GetTable<racuni>();

            try
            {
                await Racuni.InsertAsync(racun);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        
    }
}
