﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Security.AccessControl;

namespace CustomerService.API.Filters
{
    public class ErrorHandlingFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetails = new ProblemDetails
            {
                Title = "An error occured while processing your request",
                Status = (int)HttpStatusCode.InternalServerError
            };


            context.Result = new ObjectResult(problemDetails);

            context.ExceptionHandled = true;
        }
    }
}
