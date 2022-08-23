using ApiAplication.Data;
using ApiAplication.Dtos.CategoryDtos;
using ApiAplication.Models;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAplication.Med.Queries
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory, CetogoryListDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public DeleteCategoryHandler(AppDbContext context, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<CetogoryListDto> Handle(DeleteCategory request, CancellationToken cancellationToken)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == request.Id);
            //if (category == null)
            //{
            //    return NotFound();
            //}
            _context.Categories.Remove(category);


            _context.SaveChanges();
            var query = _context.Categories.AsQueryable();


            List<CategoryReturnDto> categoryReturns = _mapper.Map<List<CategoryReturnDto>>(query.ToList());
            CetogoryListDto cetogory = _mapper.Map<CetogoryListDto>(categoryReturns);
            return Task.FromResult(cetogory);
        
        }
    }
}
