using ProductsApi.Models;

namespace ProductsApi.Contracts
{
    public class PostCreateProductRequest
    {
        public string Name {get; set;}
        public decimal Price {get; set;}
    }
}