using StudentskaBanka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka.Helper
{
    public class ObjectKorisnikNavigationService
    {
        private NavigationService ns;
        private Korisnik k;

        public ObjectKorisnikNavigationService(NavigationService ns, Korisnik k)
        {
            this.Ns = ns;
            this.K = k;
        }

        public NavigationService Ns { get => ns; set => ns = value; }
        public Korisnik K { get => k; set => k = value; }
    }
}
