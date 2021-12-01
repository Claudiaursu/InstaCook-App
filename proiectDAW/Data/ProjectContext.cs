using proiectDAW.Models;
//using proiectDAW.Models.Many_to_Many;
//using proiectDAW.Models.One_to_One;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proiectDAW.Models.One_To_Many;
using proiectDAW.Models.Many_To_Many;
using proiectDAW.Models.One_To_One;

namespace proiectDAW.Data
{
    public class ProjectContext : DbContext

    {
        
        public DbSet<Utilizator> Utilizatori { get; set; }

        public DbSet<Colectie> Colectii { get; set; }

        public DbSet<Reteta> Retete { get; set; }

        public DbSet<Bucatarie> Bucatarii { get; set; }

        public DbSet<Concurs> Concursuri { get; set; }

        public DbSet<Reactie_Reteta> Reactii_Retete { get; set; }

        public DbSet<Date_Personale> Date_Personale { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // One to Many
            modelBuilder.Entity<Utilizator>()
                        .HasMany(utiliz => utiliz.Colectii)
                        .WithOne(colectie => colectie.Utilizator);

            modelBuilder.Entity<Colectie>()
                        .HasMany(colectie => colectie.Retete)
                        .WithOne(reteta => reteta.Colectie);

            modelBuilder.Entity<Bucatarie>()
                        .HasMany(bucatarie => bucatarie.Retete)
                        .WithOne(reteta => reteta.Bucatarie);

            modelBuilder.Entity<Concurs>()
                       .HasOne(concurs => concurs.Bucatarie)
                       .WithMany(bucatarie => bucatarie.Concursuri);

            // Many to Many
            modelBuilder.Entity<Reactie_Reteta>().HasKey(reactie => new { reactie.RetetaId, reactie.UtilizatorId });

            modelBuilder.Entity<Reactie_Reteta>()
                        .HasOne<Utilizator>(reactie => reactie.Utilizator)
                        .WithMany(utiliz => utiliz.Reactii_Retete)
                        .HasForeignKey(r => r.UtilizatorId);

            modelBuilder.Entity<Reactie_Reteta>()
                        .HasOne<Reteta>(reactie => reactie.Reteta)
                        .WithMany(reteta => reteta.Reactii_Retete)
                        .HasForeignKey(reactie => reactie.RetetaId);

            // One to One
            modelBuilder.Entity<Date_Personale>()
                        .HasOne(date => date.Utilizator)
                        .WithOne(utiliz => utiliz.Date_Personale)
                        .HasForeignKey<Utilizator>(utiliz => utiliz.Date_PersonaleId);

            base.OnModelCreating(modelBuilder);

        }
    }
}
