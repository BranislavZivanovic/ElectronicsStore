using System.ComponentModel.DataAnnotations;

namespace InternetProdavnica.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email polje je obavezno!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password polje je obavezno!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Sifre se ne podudaraju! Molimo pokusajte ponovo da unesete sifre!")]
        public string ConfirmPassword { get; set; }

        public string City { get; set; }
    }
}
