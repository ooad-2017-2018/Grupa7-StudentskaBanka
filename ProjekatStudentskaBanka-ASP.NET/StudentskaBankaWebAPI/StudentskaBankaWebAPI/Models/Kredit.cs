namespace StudentskaBankaWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kredit")]
    public partial class Kredit
    {
        public int ID { get; set; }

        public int ukupnoUzeto { get; set; }

        public int ukupnoZaVratiti { get; set; }

        public decimal kamata { get; set; }

        public int racunId { get; set; }
    }
}
