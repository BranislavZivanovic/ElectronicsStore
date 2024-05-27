using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Models
{
    [Table("StavkaNarudzbenice")]
    [Index(nameof(KorpaIdfk), Name = "IX_StavkaNarudzbenice_KorpaIDFK")]
    [Index(nameof(NarudzbenicaIdfk), Name = "IX_StavkaNarudzbenice_NarudzbenicaIDFK")]
    public partial class StavkaNarudzbenice
    {
        [Key]
        [Column("StavkaNarudzbeniceID")]
        public int StavkaNarudzbeniceId { get; set; }
        [Column("KorpaIDFK")]
        public int KorpaIdfk { get; set; }
        [Column("NarudzbenicaIDFK")]
        public int NarudzbenicaIdfk { get; set; }
        public double UkupnaVrednostStavke { get; set; }
        [StringLength(450)]
        public string? NazivProizvoda { get; set; }
        public int Kolicina { get; set; }

        [ForeignKey(nameof(KorpaIdfk))]
        [InverseProperty(nameof(Korpa.StavkaNarudzbenices))]
        public virtual Korpa KorpaIdfkNavigation { get; set; } = null!;
        [ForeignKey(nameof(NarudzbenicaIdfk))]
        [InverseProperty(nameof(Narudzbenica.StavkaNarudzbenices))]
        public virtual Narudzbenica NarudzbenicaIdfkNavigation { get; set; } = null!;
    }
}
