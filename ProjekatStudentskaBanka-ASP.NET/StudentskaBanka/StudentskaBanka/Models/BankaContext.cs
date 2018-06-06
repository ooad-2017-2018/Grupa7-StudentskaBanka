using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StudentskaBanka.Models
{
    public class BankaContext : DbContext
    {
        public BankaContext() : base("AzureConnection") //AzureConnection je naziv connection stringa u Web.config-u
{
        }

        //dodavanjem klasa iz modela kao DbSet iste će biti mapirane u bazu podataka
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Kredit> Kredit { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Transakcija> Transakcija { get; set; }

        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
