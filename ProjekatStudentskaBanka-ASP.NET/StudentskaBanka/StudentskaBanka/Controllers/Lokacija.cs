using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskaBanka.Controllers
{
    public class Lokacija
    {
        public double geografskaSirina { get; set; }
        public double geografskaDuzina { get; set; }
        public string naziv { get; set; }

        public Lokacija(double geografskaSirina, double geografskaDuzina, string naziv)
        {
            this.geografskaSirina = geografskaSirina;
            this.geografskaDuzina = geografskaDuzina;
            this.naziv = naziv;
        }
    }
}