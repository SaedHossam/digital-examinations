using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;

namespace WebApi
{
    public class ApiExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            context.Result = new JsonResult(new ApiResponseDto<object>(){
                IsSuccess = false,
                Message = context.Exception.Message
            });
        }
    }
}