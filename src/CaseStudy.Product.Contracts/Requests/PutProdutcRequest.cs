using CaseStudy.Product.Contracts.Model;
using System.Text.Json.Serialization;

namespace CaseStudy.Product.Contracts.Requests;

public class PutProductRequest : ProductModel
{
    [JsonIgnore]
    public Guid Id { get; set; }

}
