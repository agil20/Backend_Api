using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ApiAplication.Dtos.ProductDtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
     
        public bool IsStock { get; set; }
        public IFormFile Photo { get; set; }
        public int CategoryId { get; set; }

    }
    public class ProductCreateDtoValidator :AbstractValidator<ProductCreateDto>
    {

        public ProductCreateDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(10).WithMessage("10 dan yuxari olmaz");
            RuleFor(p => p.Price).GreaterThan(50).WithMessage("50 den boyuk olmalidir");
        }
    
    
    }
}
