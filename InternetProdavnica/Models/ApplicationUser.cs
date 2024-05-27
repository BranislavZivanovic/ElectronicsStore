using Microsoft.AspNetCore.Identity;

namespace InternetProdavnica.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Dodati bilo koje potrebno polje za registrovani nalog! Pri dodavanju dodati ga u RegisterViewModel
        public string City { get; set; }
    }
}
