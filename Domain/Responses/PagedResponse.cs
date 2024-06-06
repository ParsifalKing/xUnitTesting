using System.Net;

namespace Domain.Responses;

public class PagedResponse<T> : Response<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecord { get; set; }

    public PagedResponse(T data, int totalRecord, int pageNumber, int pageSize) : base(data)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.
        Ceiling((double)pageNumber / pageSize);
        TotalRecord = totalRecord;
    }

    public PagedResponse(T data, List<string> errors, HttpStatusCode statusCode) : base(data, errors, statusCode)
    {
    }

    public PagedResponse(T data, string errors, HttpStatusCode statusCode) : base(data, errors, statusCode)
    {
    }

    public PagedResponse(HttpStatusCode statusCode, List<string> errors) : base(statusCode, errors)
    {
    }

    public PagedResponse(HttpStatusCode statusCode, string error) : base(statusCode, error)
    {
    }

}
