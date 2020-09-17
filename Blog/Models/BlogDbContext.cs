using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace Blog.Models
{
    public class BlogDbContext: DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BlogDbContext() : base("BlogDBConnection")
        { }

    }
}