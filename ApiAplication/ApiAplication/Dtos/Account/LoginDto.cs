using FluentValidation;

namespace ApiAplication.Dtos.Account
{
    public class LoginDto
    {

      
        public string UserName { get; set; }
        public string Password { get; set; }
  
    }
    //public class LoginDtoValidator : AbstractValidator<LoginDto>
    //{
    //    public LoginDtoValidator()
    //    {
   
      
           
    //    }
    //}
}
