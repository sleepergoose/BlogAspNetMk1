using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models.IdentityModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter your Email")]
        [DisplayName("User Email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DisplayName("User password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}