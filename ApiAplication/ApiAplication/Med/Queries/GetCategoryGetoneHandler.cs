using ApiAplication.Data;
using ApiAplication.Dtos.CategoryDtos;
using ApiAplication.Models;
using AutoMapper;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAplication.Med.Queries
{
    public class GetCategoryGetoneHandler : IRequestHandler<GetCategoryGetone, CategoryReturnDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public GetCategoryGetoneHandler(AppDbContext context, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }



        public Task<CategoryReturnDto> Handle(GetCategoryGetone request, CancellationToken cancellationToken)
        {

            GetCategoryGetone getCategoryGetone = new GetCategoryGetone();
            Category category = _context.Categories.FirstOrDefault(p => p.Id == getCategoryGetone.Id);


          
            CategoryReturnDto categoryReturnDto = _mapper.Map<CategoryReturnDto>(category);
           
         

        

            return Task.FromResult( categoryReturnDto);
        }

       
    }
}
