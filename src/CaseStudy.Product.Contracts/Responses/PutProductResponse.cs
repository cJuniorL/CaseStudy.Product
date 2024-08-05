using CaseStudy.Product.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Product.Contracts.Responses
{
    public class PutProductResponse: ProductModel
    {
        public Guid Id { get; set; }
    }
}
