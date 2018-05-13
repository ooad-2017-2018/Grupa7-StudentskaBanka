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
        private static bool provjeriDatum(DateTime datum)
        {
            if ((DateTime.Now - datum).TotalDays > 3)
                return false;
        }
        

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

        public static async Task<Korisnik> dajKorisnika(string username, string password)
        {
            try
            {
                bool provjera = postojiLiUsernamePassword(username, password);
                if(provjera)
                {
                    IMobileServiceTable<korisnici> Korisnici = App.MobileService.GetTable<korisnici>();

                    IEnumerable<korisnici> tabela = await Korisnici.ReadAsync();

                    foreach (var element in tabela)
                    {
                        if (element.username.Equals(Username) && element.password.Equals(Password))
                            return element;
                    }
                }
            }
            catch(Exception r)
            {
                throw;
            }

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

            // gotovo
        }

        public void ponistiTransakciju(int idTransakcije)
        {
            //imas id transakcije, mozes naci racun primaoca i posiljaoca i iznost
            //sa racuna primaoca skinuti iznos (naravno da se moze ici u minus)
            //na racun posiljaoca staviti iznos
            

            //bit ce uradjeno nakon odredjenih provjera
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
                    if(provjeriDatum(elementT.vrijeme))
                    {
                        return true;
                        break;
                    }
            }

            return false;
        }

        public static async void dodajKorisnika(korisnici korisnik)
        {
            IMobileServiceTable<korisnici> Korisnici = App.MobileService.GetTable<korisnici>();

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
