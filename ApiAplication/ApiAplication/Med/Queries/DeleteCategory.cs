using ApiAplication.Dtos.CategoryDtos;
using MediatR;

namespace ApiAplication.Med.Queries
{
    public class DeleteCategory:IRequest<CetogoryListDto>
    {
        public int Id { get; set; }
    }
}
