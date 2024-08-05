using CaseStudy.Product.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Product.UnitTest.Builders
{
    public class PostProductRequestBuilder
    {
        private PostProductRequest _postProductRequest;
        public PostProductRequestBuilder() { 
            _postProductRequest = new PostProductRequest();
        }

        public PostProductRequestBuilder WithDescription(string description)
        {
            _postProductRequest.Description = description;
            return this;
        }

        public PostProductRequestBuilder WithPrice(decimal price)
        { 
            _postProductRequest.Price = price;
            return this;
        }

        public PostProductRequest Build()
        {
            return _postProductRequest;
        }
    }
}
