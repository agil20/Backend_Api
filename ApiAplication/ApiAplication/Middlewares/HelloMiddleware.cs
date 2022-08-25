using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ApiAplication.Middlewares
{
    public class HelloMiddleware
    {
        RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next )
        {
            _next=next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            System.Console.WriteLine("Hi");
            await  _next.Invoke(httpContext);
            System.Console.WriteLine("Thanks");
        }
    }
}
