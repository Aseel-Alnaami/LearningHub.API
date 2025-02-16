using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public decimal Idcat { get; set; }
        public string? CategoryName { get; set; }
        public string? ImagePath { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
