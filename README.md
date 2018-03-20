# Grupa 7 - TRIJUMVIRAT
## Tema: Studentska banka 
Članovi Tima:

1. Malkoč Ahmed
2. Mešić Ferhad
3. Šišić Nedim

### Opis teme
--- 

Aplikacija BankaStudent ima za cilj da organizuje, nadgleda, pomaže, upućuje i vodi računa o jednom studentu, konkretno njegovim finansijama i novcem kojim raspolaže. Općepoznato je da studenti i finansijski problemi često idu zajedno, tako da je jednom studentu od velikog značaja aplikacija koja bi mu pomogla u organizaciji finansija. Ako pogledamo jednog prosječnog studenta, da se primijetiti da on osim osnovnih troškova kao što su plaćanje kirije, režija, studentskih domova(studenti koji dolaze da studiraju iz drugih gradova), hrane itd. ima tendencije da troši i na izlaske, putovanja, zabavu, kupovanje odjeće, obuće i ostalo. Aplikacija studentu pomaže da optimalno iskoristi svoj novac, da ga uštedi, da ga potroši na pravom mjestu i u pravo vrijeme, da ga upozori ukoliko troši previše, da mu posudi novac ukoliko postoje zadovoljavajući uslovi za to. BankaStudent osim što posjeduje funckionalnosti standardnih banaka, prilagođena je i studentima.



### Procesi
---
#### Transakcija

 * Osnovni proces aplikacije je, kao što se može pretpostaviti, transakcija novca. Transakcija se može vršiti na dva načina:
 1. S računa na račun
 2. Uplatom gotovine na račun
 3. Automatska naplata
 
 Ukoliko je u pitanju prvi slučaj, pristup aplikaciji je u svojstvu korisnika. Korisnik pristupa svom računu unoseći osnovne podatke kao što su username i lozinku, nakon toga iz menija bira transakciju i unosi iznos i broj računa na koji želi prebaciti novac. Da bi transakcija bila pouzdanija, korisnik će primiti i verifikacioni kod koji će biti potrebno unijeti i transakcija će biti izvršena. Ukoliko dođe do greške, korisnik u narednih 12 sati može poništiti transakciju.
 
 Kada je u pitanju drugi slučaj, aplikaciji se pristupa u svojstvu uposlenika banke Student. Uposlenik pristupa aplikaciji koristeći odgovarajuće pristupne podatke i unosi kao i u prvom slučaju iznos i broj računa na koji se vrši uplata. U narednih 12 sati transakcija se može poništiti ukoliko je došlo do određene greške.
 
 Da bi se korisniku olakšalo plaćanje određenih stvari on može unaprijed pripremiti transakcije. Da se transakcije tj. uplate na određene račune ne bi svaki mjesec 'pješke' popunjavale i izvršavale, korisnik pripremi 'virtualne' uplatnice i jednostavnim klikom šalje zahtjev za transakciju. Npr. ovo bi bilo korisno u slučaju da neko ko svaki mjesec plaća studentski dom ili kartu za prijevoz, ne želi da gubi vrijeme svaki mjesec na unošenje istih podataka.


#### Poništavanje transakcije 

 * Kao i u procesu transakcije, i poništavanje transakcije se vrši na dva načina: na zahtjev korisnika i na zahtjev uposlenog. Korisnik u meniju bira aktivne transakcije, te mu se izlistavaju transakcije u proteklih 12 sati koje je moguće poništiti. Isti je slučaj i sa uposlenikom, osim što će on naravno morati unijeti podatke o računu čije aktivne transakcije želi vidjeti. 

#### Kreiranje računa 

 * Račun isključivo može kreirati uposlenik banke unoseći podatke koje je u pismenoj formi dobio od klijenta.
 
#### Kreiranje profila

 * Korisnik može kreirati profil. Za taj profil on ne može vezati račun. To je zadatak uposlenika (kreiranje računa). Na ovaj način on može koristiti određene funkcionalnosti, ali ne može izvršavati transakcije.

#### Brisanje računa
 * I ovaj proces se veže samo sa zaposlenog.

#### Blokiranje računa
 * Ukoliko se primijete sumnjive aktivnosti, dugovanja veća od dozvoljenih, neizmireni računi ili probijeni rokovi otplate, račun se može blokirati.
 
#### Mikrokrediti

 * Uspjeh na fakultetu donosi i određene povlastice. Bolji rezultati znače manje kamate, a lošiji veće, s tim da neko može da i ne zadovoljava uslove za dobijanje mikrokredita. Da bi se dobio mikrokredit, mora postojati određeno pokriće, odnosno da je student u određenom radnom odnosu. 

#### Konverter valuta
 * Aplikacija nudi i dodatnu mogućnost, a to je da korisnik pretvori novac iz jedne valute u drugu. Pretvaranje je čisto informativno, odnosno ne veže se za pravi novac nego služi samo da pretvori određeni iznos u neku od najčešće korištenih valuta.



### Funkcionalnosti
---
 
 * Izvršavanje transakcija s računa na račun
 * Izvršavanje transakcija fizičkom uplatom gotovine            
 * Poništavanje transakcija
 * Izvještaj dugovanja
 * Izvještaj stanja na računu
 * Pregled historije transakcija
 * Konvertovanje iz jedne valute u drugu
 * Podnošenje zahtjeva za mikrokreditom

### Akteri
---

* **Moderator** je osoba na vrhu hijerarhije navedenog sistema, vlasnik i kreator datog sistema. 
	* Njegov korisnički račun je anoniman (iz praktičnih i sigurnosnih razloga)
	* Vrši nadgledanje kompletnog u potrazi sa sumnjivim aktivnostima i greškama
  * Dodjeljuje privilegije korisnicima aplikacije

* **Uposlenici** su korisnici sistema čiji je glavni zadatak pružanje usluga klijentima. Pod tim podrazumijevamo kreiranje računa, obavljanje transakcija i sl.
	* Svaki uposlenik posjeduje vlastiti korisnički račun
	* Imaju mogućnost kreiranja i brisanja klijenata
	* Imaju mogućnost obavljanja različitih transakcija
  * Imaju mogućnost poništavanja transakcija
  * Imaju pravo pristupa svim podacima klijenta s tim da nemaju pravo mijenjati te podatke
  
* **Klijenti** su korisnici sistema koji koriste usluge banke Student
	* Imaju profil koji nije dostupan niti vidljiv drugim klijentima dok je uposlenima koji im pružaju usluge vidljiv
	* Mogu vršiti transakcije ukoliko zadovoljavaju određene uslove tipa imaju li dovoljno novca na računu
	* Mogu poništiti transakcije u propisanom vremenu
	* Imaju mogućnost ocjenjivanja kvaliteta pruženih usluga

