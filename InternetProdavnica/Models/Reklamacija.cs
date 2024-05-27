using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Models
{
    [Table("Reklamacija")]
    [Index(nameof(RacunIdfk), Name = "IX_Reklamacija_RacunIDFK")]
    public partial class Reklamacija
    {
        [Key]
        [Column("ReklamacijaID")]
        public int ReklamacijaId { get; set; }
        [Column("RacunIDFK")]
        public int RacunIdfk { get; set; }
        public string OpisReklamacije { get; set; } = null!;
        public bool Odobrena { get; set; }

        [ForeignKey(nameof(RacunIdfk))]
        [InverseProperty(nameof(Racun.Reklamacijas))]
        public virtual Racun RacunIdfkNavigation { get; set; } = null!;
    }
}
