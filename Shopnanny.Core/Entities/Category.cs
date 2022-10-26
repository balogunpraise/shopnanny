﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class Category
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; }
    }
}
