using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MyEF.Entities;

namespace MyEF
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("name=ProductContext")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
