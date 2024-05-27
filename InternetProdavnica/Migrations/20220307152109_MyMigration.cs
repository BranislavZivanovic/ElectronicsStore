using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetProdavnica.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    KategorijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKategorije = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaID);
                });

            migrationBuilder.CreateTable(
                name: "Narudzbenica",
                columns: table => new
                {
                    NarudzbenicaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: false),
                    UkupnaVrednost = table.Column<double>(type: "float", nullable: false),
                    Odobrena = table.Column<bool>(type: "bit", nullable: false),
                    Administrator = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Korisnik = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ImeIPrezime = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    AdresaIsporuke = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PostanskiBroj = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Drzava = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbenica", x => x.NarudzbenicaID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Podkategorija",
                columns: table => new
                {
                    PodkategorijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategorijaIDFK = table.Column<int>(type: "int", nullable: false),
                    NazivPodkategorije = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podkategorija", x => x.PodkategorijaID);
                    table.ForeignKey(
                        name: "FK_Podkategorija_Kategorija",
                        column: x => x.KategorijaIDFK,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaID");
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    RacunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumRacuna = table.Column<DateTime>(type: "datetime", nullable: false),
                    UkupnaVrednostRacuna = table.Column<double>(type: "float", nullable: false),
                    Izdat = table.Column<bool>(type: "bit", nullable: false),
                    NarudzbenicaIDFK = table.Column<int>(type: "int", nullable: false),
                    StavkeRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.RacunID);
                    table.ForeignKey(
                        name: "FK_Racun_Narudzbenica",
                        column: x => x.NarudzbenicaIDFK,
                        principalTable: "Narudzbenica",
                        principalColumn: "NarudzbenicaID");
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ProizvodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PodkategorijaIDFK = table.Column<int>(type: "int", nullable: false),
                    NazivProizvoda = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Konfiguracija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JedinicnaCena = table.Column<double>(type: "float", nullable: false),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ProizvodID);
                    table.ForeignKey(
                        name: "FK_Proizvod_Podkategorija",
                        column: x => x.PodkategorijaIDFK,
                        principalTable: "Podkategorija",
                        principalColumn: "PodkategorijaID");
                });

            migrationBuilder.CreateTable(
                name: "Reklamacija",
                columns: table => new
                {
                    ReklamacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RacunIDFK = table.Column<int>(type: "int", nullable: false),
                    OpisReklamacije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odobrena = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reklamacija", x => x.ReklamacijaID);
                    table.ForeignKey(
                        name: "FK_Reklamacija_Racun",
                        column: x => x.RacunIDFK,
                        principalTable: "Racun",
                        principalColumn: "RacunID");
                });

            migrationBuilder.CreateTable(
                name: "Korpa",
                columns: table => new
                {
                    KorpaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProizvodIDFK = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UkupnaVrednost = table.Column<double>(type: "float", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korpa", x => x.KorpaID);
                    table.ForeignKey(
                        name: "FK_Korpa_Proizvod",
                        column: x => x.ProizvodIDFK,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodID");
                });

            migrationBuilder.CreateTable(
                name: "Magacin",
                columns: table => new
                {
                    RedBrojMagacina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProizvodIDFK = table.Column<int>(type: "int", nullable: false),
                    Stanje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magacin", x => x.RedBrojMagacina);
                    table.ForeignKey(
                        name: "FK_Magacin_Proizvod",
                        column: x => x.ProizvodIDFK,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodID");
                });

            migrationBuilder.CreateTable(
                name: "StavkaNarudzbenice",
                columns: table => new
                {
                    StavkaNarudzbeniceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorpaIDFK = table.Column<int>(type: "int", nullable: false),
                    NarudzbenicaIDFK = table.Column<int>(type: "int", nullable: false),
                    UkupnaVrednostStavke = table.Column<double>(type: "float", nullable: false),
                    NazivProizvoda = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaNarudzbenice", x => x.StavkaNarudzbeniceID);
                    table.ForeignKey(
                        name: "FK_StavkaNarudzbenice_Korpa",
                        column: x => x.KorpaIDFK,
                        principalTable: "Korpa",
                        principalColumn: "KorpaID");
                    table.ForeignKey(
                        name: "FK_StavkaNarudzbenice_Narudzbenica",
                        column: x => x.NarudzbenicaIDFK,
                        principalTable: "Narudzbenica",
                        principalColumn: "NarudzbenicaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Korpa_ProizvodIDFK",
                table: "Korpa",
                column: "ProizvodIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Magacin_ProizvodIDFK",
                table: "Magacin",
                column: "ProizvodIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Podkategorija_KategorijaIDFK",
                table: "Podkategorija",
                column: "KategorijaIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_PodkategorijaIDFK",
                table: "Proizvod",
                column: "PodkategorijaIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_NarudzbenicaIDFK",
                table: "Racun",
                column: "NarudzbenicaIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Reklamacija_RacunIDFK",
                table: "Reklamacija",
                column: "RacunIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaNarudzbenice_KorpaIDFK",
                table: "StavkaNarudzbenice",
                column: "KorpaIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaNarudzbenice_NarudzbenicaIDFK",
                table: "StavkaNarudzbenice",
                column: "NarudzbenicaIDFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Magacin");

            migrationBuilder.DropTable(
                name: "Reklamacija");

            migrationBuilder.DropTable(
                name: "StavkaNarudzbenice");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Korpa");

            migrationBuilder.DropTable(
                name: "Narudzbenica");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Podkategorija");

            migrationBuilder.DropTable(
                name: "Kategorija");
        }
    }
}
