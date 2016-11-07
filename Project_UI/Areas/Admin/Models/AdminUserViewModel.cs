using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_UI.Areas.Admin.Models
{
    public class AdminUserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string ImagePath { get; set; }
        public string PhoneNumber { get; set; }
        public string ConfirmPassword { get; set; }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public bool IsActive { get; set; }
    }
}