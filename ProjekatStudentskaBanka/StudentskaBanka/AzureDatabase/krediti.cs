using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka.AzureDatabase
{
    class krediti
    {
        public int ID { get; set; }
        public float ukupnoUzeto { get; set; }
        public int brojRata { get; set; }
        public float kamata { get; set; }
        public float iznosRate { get; set; }
        public float ukupnoZaVratiti { get; set; }
        public int rataOtplaceno { get; set; } 
        public int racun_id { get; set; }
    }
}
