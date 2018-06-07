namespace StudentskaBankaWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Korisnik")]
    public partial class Korisnik
    {
        public int ID { get; set; }

        [Required]
        public string ime { get; set; }

        [Required]
        public string prezime { get; set; }

        public string jmbg { get; set; }

        public string adresa { get; set; }

        public string brTelefona { get; set; }

        [Required]
        public string mail { get; set; }

        [Required]
        public string password { get; set; }

        public int racunId { get; set; }
    }
}
