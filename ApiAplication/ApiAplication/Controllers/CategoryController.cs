using ApiAplication.Data;
using ApiAplication.Dtos.CategoryDtos;
using ApiAplication.Dtos.ProductDtos;
using ApiAplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {

            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }
          CategoryReturnDto categoryReturnDto = new CategoryReturnDto
          {
                Name = category.Name,
             Description = category.Description,

            };

            return Ok(categoryReturnDto);

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var query = _context.Categories.AsQueryable();
            CetogoryListDto cetogoryList = new CetogoryListDto();
            cetogoryList.Items = query.Select(p => new CategoryReturnDto
            {
                Name = p.Name,
              Description= p.Description,

            }).ToList();
            cetogoryList.TotalCount = query.Count();
            return Ok(cetogoryList);

        }
        [HttpPost]
        public IActionResult Create(CategoryCreateDto categoryCreate)
        {
            Category category = new Category
            {
                Name = categoryCreate.Name,
                Description= categoryCreate.Description
               

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
            category.Description = CategoryUpdateDto.Description;
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
