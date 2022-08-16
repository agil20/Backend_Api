using ApiAplication.Data;
using ApiAplication.Dtos.ProductDtos;
using ApiAplication.Extentions;
using ApiAplication.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public static IWebHostEnvironment _env; 
       private readonly IMapper _mapper;

        public ProductController(AppDbContext context, IWebHostEnvironment env, IMapper mapper = null)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {

            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ProductReturnTo productReturnTo = _mapper.Map<ProductReturnTo>(product);
           
            return Ok(productReturnTo);

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var query =_context.Products.AsQueryable();

            //productListDto.Items = query.Select(p=> new ProductReturnTo { 
            //Name = p.Name,
            //Price = p.Price,
            //IsStock = p.IsStock,
            //    ImageUrl = "http://localhost:6393/img/" + p.ImageUrl

            //}).ToList();

            List<ProductReturnTo> productReturnTos = _mapper.Map<List<ProductReturnTo>>(query.ToList());
            ProductListDto productListDto =_mapper.Map<ProductListDto>(productReturnTos);
            return Ok(productListDto);
         
        }
        [HttpPost]
        public IActionResult Create([FromForm]ProductCreateDto Createproduct)
        {


            bool existProduct = _context.Categories.Any(p => p.Name.ToLower() == Createproduct.Name.ToLower());
            if (existProduct) return StatusCode(409);
            if (Createproduct.Photo.IsImage())
            {
                return BadRequest();

            }
            if (Createproduct.Photo.ValidSize(200))
            {
                return BadRequest();

            }

            Product product = new Product
            {
                Name = Createproduct.Name,
                IsStock = Createproduct.IsStock,
                Price = Createproduct.Price,

                ImageUrl = Createproduct.Photo.SaveImage(_env,"img")
                ,CategoryId=Createproduct.CategoryId
            };
            product.UpdateTime = System.DateTime.Now;


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
        public IActionResult Update(int id, [FromForm]ProductUpdateDto productUpdateDto)
        {
        
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (_context.Categories.Any(p => p.Name.ToLower() == productUpdateDto.Name.ToLower() && product.Id != id))
             {
                return BadRequest();
            
            }
            if (product==null)
            {
                return NotFound();
            }
            string path = Path.Combine(_env.WebRootPath, "img",product.ImageUrl);
            if (productUpdateDto.Photo!=null)
            {
                Helper.Helper.DeleteImage(path);
            }
            product.Price = productUpdateDto.Price;
            product.IsStock = productUpdateDto.IsStock;
            product.Name = productUpdateDto.Name;
            product.CategoryId = productUpdateDto.CategoryId;
            _context.SaveChanges();
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
