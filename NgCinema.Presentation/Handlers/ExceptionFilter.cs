using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using NgCinema.Application.Exceptions;
using NgCinema.Application.DTOs.Response;

namespace NgCinema.Presentation.Handlers
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            string message = string.Empty;

            if(context.Exception is BussinesException)
            {
                statusCode = HttpStatusCode.BadRequest;
                message = context.Exception.Message;

            }
            else if(context.Exception is ConflictException)
            {
                statusCode = HttpStatusCode.Conflict;
                message = context.Exception.Message;
            }
            else if(context.Exception is NotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
                message = context.Exception.Message;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = "Ha ocurrido un error interno.";
            }

            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult( new ErrorResponse{ Message = message } );
        }
    }
}
