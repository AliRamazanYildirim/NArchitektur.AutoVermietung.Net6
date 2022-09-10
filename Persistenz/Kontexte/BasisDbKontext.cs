using Domain.Einheiten;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistenz.Kontexte
{
    public class BasisDbKontext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Marke> Marken { get; set; }
        public DbSet<Modell> Modelle { get; set; }
       

        public BasisDbKontext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ef Fluent Mapping 
            modelBuilder.Entity<Marke>(a =>
            {
                a.ToTable("Marken").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Modelle);
            });

            modelBuilder.Entity<Modell>(a =>
            {
                a.ToTable("Modelle").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.MarkeId).HasColumnName("MarkeId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.TagesPreis).HasColumnName("TagesPreis");
                a.Property(p => p.BildUrl).HasColumnName("BildUrl");
                a.HasOne(p => p.Marke);
            });


            Marke[] markeSaatgutDaten = { new(1, "Porsche"), new(2, "BMW") };
            modelBuilder.Entity<Marke>().HasData(markeSaatgutDaten);

            Modell[] markeEinheitSaatgut = { new(1,1, "Panamera",1000,""), new(2, 2, "760 LI", 1100, ""), 
                new(3, 1, "Cayenne", 1000, "") };
            modelBuilder.Entity<Modell>().HasData(markeEinheitSaatgut);
        }
    }
}
