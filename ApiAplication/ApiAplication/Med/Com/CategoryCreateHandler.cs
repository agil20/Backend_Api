using ApiAplication.Data;
using ApiAplication.Dtos.CategoryDtos;
using ApiAplication.Models;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAplication.Med.Com
{
    public class CategoryCreateHandler : IRequestHandler<CategoryCreate,CategoryReturnDto >
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoryCreateHandler(AppDbContext context, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<CategoryReturnDto> Handle(CategoryCreate request, CancellationToken cancellationToken)
        {
            Category category = new Category
            {
                Name = request.Name,
            };
            _context.Categories.Add(category);
            _context.SaveChanges();

            CategoryReturnDto categoryReturnDto = _mapper.Map<CategoryReturnDto>(category);
            return Task.FromResult(categoryReturnDto);
        }
    }
}
