using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Models.IdentityModels
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("IdentityDb") { }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}