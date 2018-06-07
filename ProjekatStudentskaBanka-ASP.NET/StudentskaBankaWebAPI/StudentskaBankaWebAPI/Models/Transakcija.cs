namespace StudentskaBankaWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transakcija")]
    public partial class Transakcija
    {
        public int ID { get; set; }

        public int posiljalacId { get; set; }

        public int primalacId { get; set; }

        public DateTime vrijeme { get; set; }

        public int iznos { get; set; }
    }
}
