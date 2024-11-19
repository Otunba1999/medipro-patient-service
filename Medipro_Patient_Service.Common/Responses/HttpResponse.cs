namespace Medipro_Patient_Service.Infrastructure.Response;

public class HttpResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}