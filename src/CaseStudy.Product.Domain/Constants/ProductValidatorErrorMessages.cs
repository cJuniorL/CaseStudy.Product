using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Product.Domain.Constants
{
    public static class ProductValidatorErrorMessages
    {
        public static string PriceLessThanAllowed = "Price need to be greater than 0!";
        public static string DescriptionCantBeEmpty = "Description cannot be empty!";
    }
}
