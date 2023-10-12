// AzureSqlApi/Middleware/ExceptionHandlingMiddleware.cs
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace AzureSqlApi.Middleware
{
    /// <summary>
    /// Middleware for handling exceptions in the ASP.NET Core application.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the request processing pipeline.</param>
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the middleware to handle exceptions.
        /// </summary>
        /// <param name="context">The current HttpContext.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Invoke the next middleware in the pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception: {ex.Message}");

                // Handle the exception and send an appropriate HTTP response
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Internal Server Error");
            }
        }
    }
}
