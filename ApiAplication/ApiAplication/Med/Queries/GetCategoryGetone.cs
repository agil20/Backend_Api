using ApiAplication.Dtos.CategoryDtos;
using MediatR;

namespace ApiAplication.Med.Queries
{
    public class GetCategoryGetone:IRequest<CategoryReturnDto>
    {
        public int Id { get; set; }
    }
}
