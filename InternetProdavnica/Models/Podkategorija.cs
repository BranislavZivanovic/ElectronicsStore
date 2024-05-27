using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Models
{
    [Table("Podkategorija")]
    [Index(nameof(KategorijaIdfk), Name = "IX_Podkategorija_KategorijaIDFK")]
    public partial class Podkategorija
    {
        public Podkategorija()
        {
            Proizvods = new HashSet<Proizvod>();
        }

        [Key]
        [Column("PodkategorijaID")]
        public int PodkategorijaId { get; set; }
        [Column("KategorijaIDFK")]
        public int KategorijaIdfk { get; set; }
        [StringLength(50)]
        public string NazivPodkategorije { get; set; } = null!;

        [ForeignKey(nameof(KategorijaIdfk))]
        [InverseProperty(nameof(Kategorija.Podkategorijas))]
        public virtual Kategorija KategorijaIdfkNavigation { get; set; } = null!;
        [InverseProperty(nameof(Proizvod.PodkategorijaIdfkNavigation))]
        public virtual ICollection<Proizvod> Proizvods { get; set; }
    }
}
