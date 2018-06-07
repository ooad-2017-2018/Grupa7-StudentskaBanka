namespace StudentskaBankaWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Racun")]
    public partial class Racun
    {
        public int ID { get; set; }

        public int stanje { get; set; }

        public bool blokiran { get; set; }
    }
}
