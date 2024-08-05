using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Product.Contracts.Responses.Base;

public class BaseMessageResponse
{ 
    public BaseMessageResponse() { }

    public BaseMessageResponse(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
}
