using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Models
{
    [Table("Racun")]
    [Index(nameof(NarudzbenicaIdfk), Name = "IX_Racun_NarudzbenicaIDFK")]
    public partial class Racun
    {
        public Racun()
        {
            Reklamacijas = new HashSet<Reklamacija>();
        }

        [Key]
        [Column("RacunID")]
        public int RacunId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DatumRacuna { get; set; }
        public double UkupnaVrednostRacuna { get; set; }
        public bool Izdat { get; set; }
        [Column("NarudzbenicaIDFK")]
        public int NarudzbenicaIdfk { get; set; }
        public string StavkeRacuna { get; set; }

        [ForeignKey(nameof(NarudzbenicaIdfk))]
        [InverseProperty(nameof(Narudzbenica.Racuns))]
        public virtual Narudzbenica NarudzbenicaIdfkNavigation { get; set; } = null!;
        [InverseProperty(nameof(Reklamacija.RacunIdfkNavigation))]
        public virtual ICollection<Reklamacija> Reklamacijas { get; set; }
    }
}
