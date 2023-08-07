using Planer_zakupowy.Backend.Domain.Exceptions;

namespace Planer_zakupowy.Backend.Api
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                switch (ex) 
                {
                    case InvalidDataProvidedException:
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync(ex.Message);
                        break;
                }
            }
        }
    }
}
