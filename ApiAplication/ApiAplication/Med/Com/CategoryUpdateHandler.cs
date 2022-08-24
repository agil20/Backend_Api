using ApiAplication.Data;
using ApiAplication.Dtos.CategoryDtos;
using ApiAplication.Models;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAplication.Med.Com
{
    public class CategoryUpdateHandler : IRequestHandler<CategoryUpdate, CategoryUpdateDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoryUpdateHandler(AppDbContext context, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<CategoryUpdateDto> Handle(CategoryUpdate request, CancellationToken cancellationToken)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == request.Id);
            //if (category == null)
            //{
            //    return NotFound();
            //}

            category.Name = request.Name;
            _context.SaveChanges();
            CategoryUpdateDto categoryUpdate = _mapper.Map<CategoryUpdateDto>(category);
            return Task.FromResult(categoryUpdate);



        }
    }
}
