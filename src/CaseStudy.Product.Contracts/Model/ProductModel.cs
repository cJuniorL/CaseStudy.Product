using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Product.Contracts.Model
{
    public abstract class ProductModel
    {
        public string Description { get; set; } = string.Empty;
        public Decimal Price { get; set; }
    }
}
