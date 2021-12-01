using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MyEF.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
