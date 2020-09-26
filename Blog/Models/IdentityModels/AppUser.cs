using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models.IdentityModels
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "Год рождения должен быть указан")]
        [DisplayName("Год рождения")]
        public int Year { get; set; }
    }
}