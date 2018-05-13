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
        //Ove funkcije su vec iskoristene u ViewModelima u kojima treba da su iskoristene
        //One su vec pozvane samo se ceka njihova implementacija
        //Njihovi prototipi se ne smiju mijenjati
        //Njihove povratne vrijednosti se ne smiju mijenjati
        //Funkcije koje si pravio mozes pozvati unutar ovih funkcija
        //One funkcije koje si pravio, mozes nastimati da ih pozovu ove fje i da proslijede njihov rezultat

        public static bool postojiLiUsernamePassword(String username, String password)
        {
            return true;
        }

        public static Korisnik dajKorisnika(String username, String password)
        {
            //pogledaj konstruktor ovog Korisnik()
            Korisnik k = new Korisnik();
            Racun r = new Racun();
            //Kad nadjes korisnika nadji i njegov racun
            k.Ime = "Popuni sve ove atribute kad ih dobijes iz baze al mi vrati korisnika.";
            k.Racun = r;
            return k;
        }

        public static bool moguceIzvrsitiTransakciju(int posiljalac, int primalac, float iznos)
        {
            //jako je bitno da je ovaj redoslijed :
            //prvo provjeri da nije koji racun blokiran od ova 2   
            //else -- postoje li navedeni korisnisi, OBAVEZNO
            if (posiljalac == 1)
                return true;
            //ima li posiljalac dovoljno da posalje
            return true; 
        }

        public static void izvrsiTransakciju(int posiljalac, int primalac, float iznos)
        {
            //napravi novu transakciju i smjesti je u bazu
        }

        public static bool mogucePonistitiTransakciju(int idTransakcije)
        {
            //ispitat
            //postoji li uopste ta transakcija !!
            //ako hoces jos kakvih uslova, ovo ono, 3 dana..
            return true;
        }

        public static void ponistiTransakciju(int idTransakcije)
        {
            //iz transakcije izvuci posiljaoca i primaoca i 
            //obrnuta logika
            //sa racuna primaoca skidas
            //na racun posiljaoca stavljas iznos
            //NE BRISES TRANSAKCIJU IZ BAZE nego pravis novu i biljezis da je ovo uradjeno u nju
        }

        public static void registrujKorisnika(String ime, String prezime, String jmbg, String adresa, String brojTelefona, String email, String sifra, bool uposlenik)
        {
            //Samo ga potrpaj u bazu;
        }
        
        /*
        private static bool provjeriDatum(DateTime datum)
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
                        if (element.username.Equals(username) && element.password.Equals(password))
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

        */
    }
}
