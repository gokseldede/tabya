using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_VM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "EMail adresi giriniz")]
        [EmailAddress(ErrorMessage = "Lütfen email formatında giriniz")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Parola giriniz")]
        public string Password { get; set; }
    }
}
