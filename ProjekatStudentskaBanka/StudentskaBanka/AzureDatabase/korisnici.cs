﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka
{
    public class korisnici
    {
        public int ID { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string jmbg { get; set; }
        public string brojTelefona { get; set; }
        public string adresa { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool uposlen { get; set; }
        public int racun_id { get; set; }

    }
}
