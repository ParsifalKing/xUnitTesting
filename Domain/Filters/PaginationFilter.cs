namespace Domain.Filters;

public class PaginationFilter
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }

    public PaginationFilter()
    {
        PageSize = 10;
        PageNumber = 1;
    }

    public PaginationFilter(int pageNumber, int pageSize)
    {

        PageSize = pageSize < 10 ? 10 : pageSize;
        PageNumber = pageNumber < 1 ? 1 : pageNumber;
    }

}
