using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Models
{
    [Table("Magacin")]
    [Index(nameof(ProizvodIdfk), Name = "IX_Magacin_ProizvodIDFK")]
    public partial class Magacin
    {
        [Key]
        public int RedBrojMagacina { get; set; }
        [Column("ProizvodIDFK")]
        public int ProizvodIdfk { get; set; }
        public int Stanje { get; set; }

        [ForeignKey(nameof(ProizvodIdfk))]
        [InverseProperty(nameof(Proizvod.Magacins))]
        public virtual Proizvod ProizvodIdfkNavigation { get; set; } = null!;
    }
}
