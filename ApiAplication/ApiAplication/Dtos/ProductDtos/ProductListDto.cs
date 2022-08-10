using System.Collections.Generic;

namespace ApiAplication.Dtos.ProductDtos
{
    public class ProductListDto
    {
        public int TotalCount { get; set; }
        public List<ProductReturnTo> Items { get; set; }
    }
}
