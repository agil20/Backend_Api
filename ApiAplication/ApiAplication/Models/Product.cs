using ApiAplication.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;

namespace ApiAplication.Models
{
    public class Product:BaseEntity
    {
   
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsStock{ get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
