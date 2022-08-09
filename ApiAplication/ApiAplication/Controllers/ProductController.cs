using ApiAplication.Data;
using ApiAplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            if (product==null)
            {
                return NotFound();
            }
            return Ok(product);

        }
        [HttpGet]
        public IActionResult GetAll(int id)
        {

            return StatusCode(200, _context.Products.ToList());
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok();
        
        }
        [HttpPatch("{id}")]
        public IActionResult ChanegeIsPrice(int id,int price)
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
        [HttpDelete]
        public IActionResult ChanegeIsPrice(int id)
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
