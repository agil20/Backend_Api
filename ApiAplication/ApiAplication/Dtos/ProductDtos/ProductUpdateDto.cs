using Microsoft.AspNetCore.Http;

namespace ApiAplication.Dtos.ProductDtos
{
    public class ProductUpdateDto
    {

        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsStock { get; set; }
        public IFormFile Photo { get; set; }
      
        public int CategoryId { get; set; }
    }
}
