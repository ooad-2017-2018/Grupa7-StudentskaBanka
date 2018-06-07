namespace StudentskaBankaWebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BankaModel : DbContext
    {
        public BankaModel()
            : base("name=BankaModel")
        {
        }

        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Kredit> Kredit { get; set; }
        public virtual DbSet<Racun> Racun { get; set; }
        public virtual DbSet<Transakcija> Transakcija { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
