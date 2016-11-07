using System.ComponentModel.DataAnnotations;

namespace Project_UI.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "EMail adresi giriniz")]
        [EmailAddress(ErrorMessage = "Lütfen email formatında giriniz")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Parola giriniz")]
        public string Password { get; set; }
    }
}
