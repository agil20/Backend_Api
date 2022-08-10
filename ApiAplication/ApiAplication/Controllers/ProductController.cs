using ApiAplication.Data;
using ApiAplication.Dtos.ProductDtos;
using ApiAplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {

            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ProductReturnTo productReturnTo = new ProductReturnTo
            {
                Name=product.Name,
                Price=product.Price,
                IsStock=product.IsStock,

            };
           
            return Ok(productReturnTo);

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var query =_context.Products.AsQueryable();
            ProductListDto productListDto = new ProductListDto();
            productListDto.Items = query.Select(p=> new ProductReturnTo { 
            Name = p.Name,
            Price = p.Price,
            IsStock = p.IsStock,
            
            }).ToList();
            productListDto.TotalCount=query.Count();
            return Ok();
         
        }
        [HttpPost]
        public IActionResult Create(ProductCreateDto Createproduct)
        {
            Product product = new Product
            {
                Name = Createproduct.Name,
                IsStock = Createproduct.IsStock,
                Price = Createproduct.Price,

            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok();

        }
        [HttpPatch("{id}")]
        public IActionResult ChanegeIsPrice(int id, int price)
        {
            Product dbproduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (dbproduct == null)
            {
                return NotFound();
            }
            dbproduct.Price = price;

            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductUpdateDto productUpdateDto)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product==null)
            {
                return NotFound();
            }
            product.Price = productUpdateDto.Price;
            product.IsStock = productUpdateDto.IsStock;
            product.Name = productUpdateDto.Name;
            return Ok();
        
        
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Product dbproduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (dbproduct == null)
            {
                return NotFound();
            }
            _context.Products.Remove(dbproduct);
           

            _context.SaveChanges();
            return Ok();
        }
    }
}
