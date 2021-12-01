using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEF.Entities;
using System.Data.Entity;

namespace MyEF
{
    class BloggingContext : DbContext
    {
        public BloggingContext() : base("name=ProductContext")
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}

