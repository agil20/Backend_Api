using Microsoft.AspNetCore.Http;

namespace ApiAplication.Dtos.ProductDtos
{
    public class ProductReturnTo
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsStock { get; set; }
        public string ImageUrl { get; set; }
      
    }
}
