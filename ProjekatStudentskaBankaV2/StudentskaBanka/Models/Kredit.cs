using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka.Models
{
    public class Kredit
    {
        private int id;
        private float ukupnoUzeto;
        private int brojRata;
        private float kamata;
        private float iznosRate;
        private float ukupnoZaVratiti;
        private int rataOtplaceno;

        public int Id { get => id; set => id = value; }
        public float UkupnoUzeto { get => ukupnoUzeto; set => ukupnoUzeto = value; }
        public int BrojRata { get => brojRata; set => brojRata = value; }
        public float Kamata { get => kamata; set => kamata = value; }
        public float IznosRate { get => iznosRate; set => iznosRate = value; }
        public float UkupnoZaVratiti { get => ukupnoZaVratiti; set => ukupnoZaVratiti = value; }
        public int RataOtplaceno { get => rataOtplaceno; set => rataOtplaceno = value; }

        static int globalId = 1;

        public Kredit(float ukupnoUzeto, int brojRata, float kamata, float iznosRate, float ukupnoZaVratiti, int rataOtplaceno)
        {
            Id = globalId;
            globalId += 1;
            UkupnoUzeto = ukupnoUzeto;
            BrojRata = brojRata;
            Kamata = kamata;
            IznosRate = iznosRate;
            UkupnoZaVratiti = ukupnoZaVratiti;
            RataOtplaceno = rataOtplaceno;
        }
    }
}
