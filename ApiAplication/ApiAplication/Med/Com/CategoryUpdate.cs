using ApiAplication.Dtos.CategoryDtos;
using MediatR;

namespace ApiAplication.Med.Com
{
    public class CategoryUpdate:IRequest<CategoryUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
