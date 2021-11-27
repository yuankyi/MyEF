﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEF.Entities
{
    public class Category
    {
        private readonly ObservableListSource<Product> _products =
                new ObservableListSource<Product>();

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ObservableListSource<Product> Products { get { return _products; } }
    }
}
