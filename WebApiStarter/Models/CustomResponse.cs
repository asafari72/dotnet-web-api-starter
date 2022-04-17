using System.Net;

namespace WebApiStarter.Models
{
    public class CustomResponse
    {

        public int status { get; set; }
        public string message { get; set; } = null!;
        public object result { get; set; }


        public static CustomResponse Create(HttpStatusCode statusCode, object result = null, string errorMessage = null)
        {
            return new CustomResponse(statusCode, result, errorMessage);
        }

        protected CustomResponse(HttpStatusCode _status, object? _result = null, string? _message = null)
        {
            status = (int)_status;
            message = _message;
            result = _result;
        }

    }
}
