using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka.Models
{
    public class Racun
    {
        private float stanje;
        private bool blokiran;
        private List<Kredit> listaKredita;
        
        public bool Blokiran { get => blokiran; set => blokiran = value; }
        public List<Kredit> ListaKredita { get => listaKredita; set => listaKredita = value; }
        public float Stanje { get => stanje; set => stanje = value; }

        public Racun()
        {
            Stanje = 0;
            Blokiran = false;
            ListaKredita = new List<Kredit>();
        }
    }
}
