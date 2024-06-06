using System.Net;

namespace Domain.Responses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public List<string>? Errors { get; set; }
    public T? Data { get; set; }


    public Response(T data)
    {
        Data = data;
        StatusCode = 200;
    }
    public Response(T data, string error, HttpStatusCode statusCode)
    {
        Data = data;
        StatusCode = (int)statusCode;
        Errors!.Add(error);
    }
    public Response(T data, List<string> errors, HttpStatusCode statusCode)
    {
        Data = data;
        StatusCode = (int)statusCode;
        Errors = errors;
    }
    public Response(HttpStatusCode statusCode, List<string> errors)
    {
        StatusCode = (int)statusCode;
        Errors = errors;
    }
    public Response(HttpStatusCode statusCode, string error)
    {
        StatusCode = (int)statusCode;
        Errors?.Add(error);
    }

}
