using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using WebApiStarter.Middlewares;
using WebApiStarter.Models;

namespace WebApiStarter.Middlewares
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var currentBody = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                //set the current response to the memorystream.
                context.Response.Body = memoryStream;

                await _next(context);

                // reset the body 
                context.Response.Body = currentBody;
                memoryStream.Seek(0, SeekOrigin.Begin);

                var readToEnd = new StreamReader(memoryStream).ReadToEnd();
                var a = readToEnd.GetType();
                var objResult = JsonConvert.DeserializeObject(readToEnd);
                var result = CustomResponse.Create((HttpStatusCode)context.Response.StatusCode, objResult, null);
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
        }
    }
}

public static class ResponseMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomResponse(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ResponseMiddleware>();
    }
}