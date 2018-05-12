using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka.AzureDatabase
{
    class transakcije
    {
        public int ID { get; set; }
        public int primalac_id { get; set; }
        public int posiljalac_id { get; set; }
        public DateTime vrijeme { get; set; }
        public float iznos { get; set; }

    }
}
