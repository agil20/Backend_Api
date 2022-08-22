﻿using ApiAplication.Data;
using ApiAplication.Dtos.CategoryDtos;
using ApiAplication.Dtos.ProductDtos;
using ApiAplication.Med.Queries;
using ApiAplication.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator mediatr;

        public CategoryController(AppDbContext context, IMapper mapper = null, IMediator mediatr = null)
        {
            _context = context;
            _mapper = mapper;
            this.mediatr = mediatr;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {


            //var query=new GetCategoryGetone() { 
            //Id = id };
            //return Task.FromResult(await mediatr.Send(query));
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }
          CategoryReturnDto categoryReturnDto =_mapper.Map<CategoryReturnDto>(category);
         

            return Ok(categoryReturnDto);

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var query = _context.Categories.AsQueryable();
          

            List<CategoryReturnDto > categoryReturns=_mapper.Map<List<CategoryReturnDto>>(query.ToList());
            CetogoryListDto cetogory = _mapper.Map<CetogoryListDto>(categoryReturns);
          

            return Ok(cetogory);
          

        }
        [HttpPost]
        public IActionResult Create(CategoryCreateDto categoryCreate)
        {
            Category category = new Category
            {
                Name = categoryCreate.Name,
            
               

            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok();

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryUpdateDto CategoryUpdateDto)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            category.Name = CategoryUpdateDto.Name;
      
            return Ok(category);


        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);


            _context.SaveChanges();
            return Ok();
        }
    }
}
