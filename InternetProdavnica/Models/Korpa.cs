using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Models
{
    [Table("Korpa")]
    [Index(nameof(ProizvodIdfk), Name = "IX_Korpa_ProizvodIDFK")]
    public partial class Korpa
    {
        public Korpa()
        {
            StavkaNarudzbenices = new HashSet<StavkaNarudzbenice>();
        }

        [Key]
        [Column("KorpaID")]
        public int KorpaId { get; set; }
        [Column("ProizvodIDFK")]
        public int ProizvodIdfk { get; set; }
        public int Kolicina { get; set; }
        [Column("KorisnikID")]
        public string KorisnikId { get; set; } = null!;
        public double UkupnaVrednost { get; set; }
        public bool Active { get; set; }

        [ForeignKey(nameof(ProizvodIdfk))]
        [InverseProperty(nameof(Proizvod.Korpas))]
        public virtual Proizvod ProizvodIdfkNavigation { get; set; } = null!;
        [InverseProperty(nameof(StavkaNarudzbenice.KorpaIdfkNavigation))]
        public virtual ICollection<StavkaNarudzbenice> StavkaNarudzbenices { get; set; }
    }
}
