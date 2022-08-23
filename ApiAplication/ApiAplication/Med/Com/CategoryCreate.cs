using ApiAplication.Dtos.CategoryDtos;
using MediatR;

namespace ApiAplication.Med.Com
{
    public class CategoryCreate:IRequest<CategoryReturnDto>
    {
        public string Name { get; set; }
    }
}
