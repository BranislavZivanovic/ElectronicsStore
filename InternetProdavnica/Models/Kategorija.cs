using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Models
{
    [Table("Kategorija")]
    public partial class Kategorija
    {
        public Kategorija()
        {
            Podkategorijas = new HashSet<Podkategorija>();
        }

        [Key]
        [Column("KategorijaID")]
        public int KategorijaId { get; set; }
        [StringLength(50)]
        public string NazivKategorije { get; set; } = null!;

        [InverseProperty(nameof(Podkategorija.KategorijaIdfkNavigation))]
        public virtual ICollection<Podkategorija> Podkategorijas { get; set; }
    }
}
