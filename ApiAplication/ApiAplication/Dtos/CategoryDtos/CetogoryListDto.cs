using ApiAplication.Dtos.ProductDtos;
using System.Collections.Generic;

namespace ApiAplication.Dtos.CategoryDtos
{
    public class CetogoryListDto
    {
        public int TotalCount { get; set; }
        public List<CategoryReturnDto> Items { get; set; }
    }
}
