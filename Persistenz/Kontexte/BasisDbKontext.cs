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
            modelBuilder.Entity<Marke>(a =>
            {
                a.ToTable("Marken").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
            });



            Marke[] markeSaatgutDaten = { new(1, "Porsche"), new(2, "BMW") };
            modelBuilder.Entity<Marke>().HasData(markeSaatgutDaten);

           
        }
    }
}
