using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Models
{
    [Table("Proizvod")]
    [Index(nameof(PodkategorijaIdfk), Name = "IX_Proizvod_PodkategorijaIDFK")]
    public partial class Proizvod
    {
        public Proizvod()
        {
            Korpas = new HashSet<Korpa>();
            Magacins = new HashSet<Magacin>();
        }

        [Key]
        [Column("ProizvodID")]
        public int ProizvodId { get; set; }
        [Column("PodkategorijaIDFK")]
        public int PodkategorijaIdfk { get; set; }
        [StringLength(50)]
        public string NazivProizvoda { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public string Konfiguracija { get; set; } = null!;
        public double JedinicnaCena { get; set; }
        public bool Aktivan { get; set; }
        public string Slika { get; set; } = null!;
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(PodkategorijaIdfk))]
        [InverseProperty(nameof(Podkategorija.Proizvods))]
        public virtual Podkategorija PodkategorijaIdfkNavigation { get; set; } = null!;
        [InverseProperty(nameof(Korpa.ProizvodIdfkNavigation))]
        public virtual ICollection<Korpa> Korpas { get; set; }
        [InverseProperty(nameof(Magacin.ProizvodIdfkNavigation))]
        public virtual ICollection<Magacin> Magacins { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        [Required]
        public IFormFile ImageFile { get; set; }

    }
}
