﻿// <auto-generated />
using System;
using InternetProdavnica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InternetProdavnica.Migrations
{
    [DbContext(typeof(InternetProdavnicaContext))]
    partial class InternetProdavnicaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InternetProdavnica.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("InternetProdavnica.Models.Kategorija", b =>
                {
                    b.Property<int>("KategorijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KategorijaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategorijaId"), 1L, 1);

                    b.Property<string>("NazivKategorije")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("KategorijaId");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Korpa", b =>
                {
                    b.Property<int>("KorpaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KorpaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorpaId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("KorisnikId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("KorisnikID");

                    b.Property<int>("ProizvodIdfk")
                        .HasColumnType("int")
                        .HasColumnName("ProizvodIDFK");

                    b.Property<double>("UkupnaVrednost")
                        .HasColumnType("float");

                    b.HasKey("KorpaId");

                    b.HasIndex(new[] { "ProizvodIdfk" }, "IX_Korpa_ProizvodIDFK");

                    b.ToTable("Korpa");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Magacin", b =>
                {
                    b.Property<int>("RedBrojMagacina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RedBrojMagacina"), 1L, 1);

                    b.Property<int>("ProizvodIdfk")
                        .HasColumnType("int")
                        .HasColumnName("ProizvodIDFK");

                    b.Property<int>("Stanje")
                        .HasColumnType("int");

                    b.HasKey("RedBrojMagacina");

                    b.HasIndex(new[] { "ProizvodIdfk" }, "IX_Magacin_ProizvodIDFK");

                    b.ToTable("Magacin");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Narudzbenica", b =>
                {
                    b.Property<int>("NarudzbenicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NarudzbenicaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NarudzbenicaId"), 1L, 1);

                    b.Property<string>("Administrator")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdresaIsporuke")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime");

                    b.Property<string>("Drzava")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImeIprezime")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ImeIPrezime");

                    b.Property<string>("Korisnik")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Odobrena")
                        .HasColumnType("bit");

                    b.Property<string>("PostanskiBroj")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("UkupnaVrednost")
                        .HasColumnType("float");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NarudzbenicaId");

                    b.ToTable("Narudzbenica");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Podkategorija", b =>
                {
                    b.Property<int>("PodkategorijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PodkategorijaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PodkategorijaId"), 1L, 1);

                    b.Property<int>("KategorijaIdfk")
                        .HasColumnType("int")
                        .HasColumnName("KategorijaIDFK");

                    b.Property<string>("NazivPodkategorije")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PodkategorijaId");

                    b.HasIndex(new[] { "KategorijaIdfk" }, "IX_Podkategorija_KategorijaIDFK");

                    b.ToTable("Podkategorija");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Proizvod", b =>
                {
                    b.Property<int>("ProizvodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProizvodID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProizvodId"), 1L, 1);

                    b.Property<bool>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("JedinicnaCena")
                        .HasColumnType("float");

                    b.Property<string>("Konfiguracija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivProizvoda")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PodkategorijaIdfk")
                        .HasColumnType("int")
                        .HasColumnName("PodkategorijaIDFK");

                    b.Property<string>("Slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProizvodId");

                    b.HasIndex(new[] { "PodkategorijaIdfk" }, "IX_Proizvod_PodkategorijaIDFK");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Racun", b =>
                {
                    b.Property<int>("RacunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RacunID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RacunId"), 1L, 1);

                    b.Property<DateTime>("DatumRacuna")
                        .HasColumnType("datetime");

                    b.Property<bool>("Izdat")
                        .HasColumnType("bit");

                    b.Property<int>("NarudzbenicaIdfk")
                        .HasColumnType("int")
                        .HasColumnName("NarudzbenicaIDFK");

                    b.Property<string>("StavkeRacuna")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UkupnaVrednostRacuna")
                        .HasColumnType("float");

                    b.HasKey("RacunId");

                    b.HasIndex(new[] { "NarudzbenicaIdfk" }, "IX_Racun_NarudzbenicaIDFK");

                    b.ToTable("Racun");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Reklamacija", b =>
                {
                    b.Property<int>("ReklamacijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReklamacijaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReklamacijaId"), 1L, 1);

                    b.Property<bool>("Odobrena")
                        .HasColumnType("bit");

                    b.Property<string>("OpisReklamacije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RacunIdfk")
                        .HasColumnType("int")
                        .HasColumnName("RacunIDFK");

                    b.HasKey("ReklamacijaId");

                    b.HasIndex(new[] { "RacunIdfk" }, "IX_Reklamacija_RacunIDFK");

                    b.ToTable("Reklamacija");
                });

            modelBuilder.Entity("InternetProdavnica.Models.StavkaNarudzbenice", b =>
                {
                    b.Property<int>("StavkaNarudzbeniceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StavkaNarudzbeniceID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StavkaNarudzbeniceId"), 1L, 1);

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("KorpaIdfk")
                        .HasColumnType("int")
                        .HasColumnName("KorpaIDFK");

                    b.Property<int>("NarudzbenicaIdfk")
                        .HasColumnType("int")
                        .HasColumnName("NarudzbenicaIDFK");

                    b.Property<string>("NazivProizvoda")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("UkupnaVrednostStavke")
                        .HasColumnType("float");

                    b.HasKey("StavkaNarudzbeniceId");

                    b.HasIndex(new[] { "KorpaIdfk" }, "IX_StavkaNarudzbenice_KorpaIDFK");

                    b.HasIndex(new[] { "NarudzbenicaIdfk" }, "IX_StavkaNarudzbenice_NarudzbenicaIDFK");

                    b.ToTable("StavkaNarudzbenice");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("InternetProdavnica.Models.Korpa", b =>
                {
                    b.HasOne("InternetProdavnica.Models.Proizvod", "ProizvodIdfkNavigation")
                        .WithMany("Korpas")
                        .HasForeignKey("ProizvodIdfk")
                        .IsRequired()
                        .HasConstraintName("FK_Korpa_Proizvod");

                    b.Navigation("ProizvodIdfkNavigation");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Magacin", b =>
                {
                    b.HasOne("InternetProdavnica.Models.Proizvod", "ProizvodIdfkNavigation")
                        .WithMany("Magacins")
                        .HasForeignKey("ProizvodIdfk")
                        .IsRequired()
                        .HasConstraintName("FK_Magacin_Proizvod");

                    b.Navigation("ProizvodIdfkNavigation");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Podkategorija", b =>
                {
                    b.HasOne("InternetProdavnica.Models.Kategorija", "KategorijaIdfkNavigation")
                        .WithMany("Podkategorijas")
                        .HasForeignKey("KategorijaIdfk")
                        .IsRequired()
                        .HasConstraintName("FK_Podkategorija_Kategorija");

                    b.Navigation("KategorijaIdfkNavigation");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Proizvod", b =>
                {
                    b.HasOne("InternetProdavnica.Models.Podkategorija", "PodkategorijaIdfkNavigation")
                        .WithMany("Proizvods")
                        .HasForeignKey("PodkategorijaIdfk")
                        .IsRequired()
                        .HasConstraintName("FK_Proizvod_Podkategorija");

                    b.Navigation("PodkategorijaIdfkNavigation");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Racun", b =>
                {
                    b.HasOne("InternetProdavnica.Models.Narudzbenica", "NarudzbenicaIdfkNavigation")
                        .WithMany("Racuns")
                        .HasForeignKey("NarudzbenicaIdfk")
                        .IsRequired()
                        .HasConstraintName("FK_Racun_Narudzbenica");

                    b.Navigation("NarudzbenicaIdfkNavigation");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Reklamacija", b =>
                {
                    b.HasOne("InternetProdavnica.Models.Racun", "RacunIdfkNavigation")
                        .WithMany("Reklamacijas")
                        .HasForeignKey("RacunIdfk")
                        .IsRequired()
                        .HasConstraintName("FK_Reklamacija_Racun");

                    b.Navigation("RacunIdfkNavigation");
                });

            modelBuilder.Entity("InternetProdavnica.Models.StavkaNarudzbenice", b =>
                {
                    b.HasOne("InternetProdavnica.Models.Korpa", "KorpaIdfkNavigation")
                        .WithMany("StavkaNarudzbenices")
                        .HasForeignKey("KorpaIdfk")
                        .IsRequired()
                        .HasConstraintName("FK_StavkaNarudzbenice_Korpa");

                    b.HasOne("InternetProdavnica.Models.Narudzbenica", "NarudzbenicaIdfkNavigation")
                        .WithMany("StavkaNarudzbenices")
                        .HasForeignKey("NarudzbenicaIdfk")
                        .IsRequired()
                        .HasConstraintName("FK_StavkaNarudzbenice_Narudzbenica");

                    b.Navigation("KorpaIdfkNavigation");

                    b.Navigation("NarudzbenicaIdfkNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("InternetProdavnica.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("InternetProdavnica.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternetProdavnica.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("InternetProdavnica.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InternetProdavnica.Models.Kategorija", b =>
                {
                    b.Navigation("Podkategorijas");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Korpa", b =>
                {
                    b.Navigation("StavkaNarudzbenices");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Narudzbenica", b =>
                {
                    b.Navigation("Racuns");

                    b.Navigation("StavkaNarudzbenices");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Podkategorija", b =>
                {
                    b.Navigation("Proizvods");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Proizvod", b =>
                {
                    b.Navigation("Korpas");

                    b.Navigation("Magacins");
                });

            modelBuilder.Entity("InternetProdavnica.Models.Racun", b =>
                {
                    b.Navigation("Reklamacijas");
                });
#pragma warning restore 612, 618
        }
    }
}
