using System.Net;

namespace Todo.Application.Common.Response;

public class Error : Generic
{
    public string Message { get; set; }

    public Error(int statuscode, string message) : base()
    {
        StatusCode = statuscode;
        Message = message;
    }
    public Error(HttpStatusCode statusCode, string message) : this((int)statusCode, message) { }
}
