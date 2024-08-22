namespace Medipro_Patient_Service.Common.Utilities;

public class PagedResult<T>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public List<T>? Items { get; set; }
}