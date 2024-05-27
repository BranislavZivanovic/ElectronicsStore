using System.ComponentModel.DataAnnotations;

namespace InternetProdavnica.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required(ErrorMessage = "Morate dati ime roli!")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
