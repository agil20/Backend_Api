using FluentValidation;

namespace ApiAplication.Dtos.Account
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Fullname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CheckPassword { get; set; }
    }
    public class RegisterDtoValidator : AbstractValidator<RegisterDto> 
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Fullname).NotEmpty();
            RuleFor(p => p.Password).NotEmpty().MinimumLength(8);
            RuleFor(p => p.UserName).NotEmpty();
            RuleFor(p => p).Custom((r, context) =>
            {
                if (r.Password!=r.CheckPassword)
                {
                    context.AddFailure("Password", "Duzgun deyil");
                }


            }
            );
        }
    
    
    
    }
}
