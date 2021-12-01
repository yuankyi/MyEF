using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEF.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
