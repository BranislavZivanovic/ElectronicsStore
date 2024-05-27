using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InternetProdavnica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InternetProdavnica.Data
{
    public partial class InternetProdavnicaContext : IdentityDbContext<ApplicationUser>
    {
        public InternetProdavnicaContext()
        {
        }

        public InternetProdavnicaContext(DbContextOptions<InternetProdavnicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategorija> Kategorijas { get; set; } = null!;
        public virtual DbSet<Korpa> Korpas { get; set; } = null!;
        public virtual DbSet<Magacin> Magacins { get; set; } = null!;
        public virtual DbSet<Narudzbenica> Narudzbenicas { get; set; } = null!;
        public virtual DbSet<Podkategorija> Podkategorijas { get; set; } = null!;
        public virtual DbSet<Proizvod> Proizvods { get; set; } = null!;
        public virtual DbSet<Racun> Racuns { get; set; } = null!;
        public virtual DbSet<Reklamacija> Reklamacijas { get; set; } = null!;
        public virtual DbSet<StavkaNarudzbenice> StavkaNarudzbenices { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Korpa>(entity =>
            {
                entity.HasOne(d => d.ProizvodIdfkNavigation)
                    .WithMany(p => p.Korpas)
                    .HasForeignKey(d => d.ProizvodIdfk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korpa_Proizvod");
            });

            modelBuilder.Entity<Magacin>(entity =>
            {
                entity.HasOne(d => d.ProizvodIdfkNavigation)
                    .WithMany(p => p.Magacins)
                    .HasForeignKey(d => d.ProizvodIdfk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Magacin_Proizvod");
            });

            modelBuilder.Entity<Podkategorija>(entity =>
            {
                entity.HasOne(d => d.KategorijaIdfkNavigation)
                    .WithMany(p => p.Podkategorijas)
                    .HasForeignKey(d => d.KategorijaIdfk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Podkategorija_Kategorija");
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.HasOne(d => d.PodkategorijaIdfkNavigation)
                    .WithMany(p => p.Proizvods)
                    .HasForeignKey(d => d.PodkategorijaIdfk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proizvod_Podkategorija");
            });

            modelBuilder.Entity<Racun>(entity =>
            {
                entity.HasOne(d => d.NarudzbenicaIdfkNavigation)
                    .WithMany(p => p.Racuns)
                    .HasForeignKey(d => d.NarudzbenicaIdfk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Racun_Narudzbenica");
            });

            modelBuilder.Entity<Reklamacija>(entity =>
            {
                entity.HasOne(d => d.RacunIdfkNavigation)
                    .WithMany(p => p.Reklamacijas)
                    .HasForeignKey(d => d.RacunIdfk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reklamacija_Racun");
            });

            modelBuilder.Entity<StavkaNarudzbenice>(entity =>
            {
                entity.HasOne(d => d.KorpaIdfkNavigation)
                    .WithMany(p => p.StavkaNarudzbenices)
                    .HasForeignKey(d => d.KorpaIdfk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StavkaNarudzbenice_Korpa");

                entity.HasOne(d => d.NarudzbenicaIdfkNavigation)
                    .WithMany(p => p.StavkaNarudzbenices)
                    .HasForeignKey(d => d.NarudzbenicaIdfk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StavkaNarudzbenice_Narudzbenica");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
