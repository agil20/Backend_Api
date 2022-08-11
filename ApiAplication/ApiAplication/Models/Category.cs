using ApiAplication.Dtos.ProductDtos;
using System.Collections.Generic;

namespace ApiAplication.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

    }
}
