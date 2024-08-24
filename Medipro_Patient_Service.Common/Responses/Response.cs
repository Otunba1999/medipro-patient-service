namespace Medipro_Patient_Service.Common.Responses;

public class Response<T>
{
    public int StatusCode { get; init; }
    public string Message { get; init; } = string.Empty;
    public T? Data { get; set; }
}