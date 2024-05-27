using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace InternetProdavnica.Models
{
    [Table("Narudzbenica")]
    public partial class Narudzbenica
    {
        public Narudzbenica()
        {
            Racuns = new HashSet<Racun>();
            StavkaNarudzbenices = new HashSet<StavkaNarudzbenice>();
        }

        [Key]
        [Column("NarudzbenicaID")]
        public int NarudzbenicaId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Datum { get; set; }
        public double UkupnaVrednost { get; set; }
        public bool Odobrena { get; set; }
        [StringLength(450)]
        public string? Administrator { get; set; }
        [ValidateNever]
        [StringLength(450)]
        public string Korisnik { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        [Column("ImeIPrezime")]
        [StringLength(450)]
        public string ImeIprezime { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        [StringLength(450)]
        public string AdresaIsporuke { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        [StringLength(450)]
        public string Grad { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        [StringLength(450)]
        public string PostanskiBroj { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        [StringLength(450)]
        public string Drzava { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        [StringLength(450)]
        public string Telefon { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        [StringLength(450)]
        public string email { get; set; } = null!;

        [InverseProperty(nameof(Racun.NarudzbenicaIdfkNavigation))]
        public virtual ICollection<Racun> Racuns { get; set; }
        [InverseProperty(nameof(StavkaNarudzbenice.NarudzbenicaIdfkNavigation))]
        public virtual ICollection<StavkaNarudzbenice> StavkaNarudzbenices { get; set; }
    }
}
