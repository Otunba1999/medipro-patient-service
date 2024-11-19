using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using medipro_patient_service.Application.Interfaces.HttpService;
using Medipro_Patient_Service.Common.Requests;
using Medipro_Patient_Service.Common.Responses;
using Medipro_Patient_Service.Common.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Medipro_Patient_Service.Infrastructure.HttpService;

public class AppointmentService : IHttpService<AppointmentRequest>
{
    private readonly IHttpClientFactory _httpClientFactory = null;
    private readonly IConfiguration _configuration = null!;
    private readonly ILogger<AppointmentService> _logger = null!;

    public AppointmentService(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        ILogger<AppointmentService> logger) => (_httpClientFactory, _configuration, _logger) =
        (httpClientFactory, configuration, logger);

    // public async Task<Todo[]> GetUserTodosAsync(int userId)
    // {
    //     // Create the client
    //     string? httpClientName = _configuration["HttpClientName:AppointmentClient"];
    //     using HttpClient client = _httpClientFactory.CreateClient(httpClientName ?? "");
    //
    //     try
    //     {
    //         // Make HTTP GET request
    //         // Parse JSON response deserialize into Todo type
    //         Todo[]? todos = await client.GetFromJsonAsync<Todo[]>(
    //             $"todos?userId={userId}",
    //             new JsonSerializerOptions(JsonSerializerDefaults.Web));
    //
    //         return todos ?? [];
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError("Error getting something fun to say: {Error}", ex);
    //     }
    //
    //     return [];
    // }

    public Task<List<AppointmentRequest>> GetAll(string subUrl, Dictionary<string, string>? queryParams = null,
        Dictionary<string, string>? headers = null)
    {
        throw new NotImplementedException();
    }

    public Task<AppointmentRequest> GetById(long id, string subUrl, Dictionary<string, string>? queryParams = null,
        Dictionary<string, string>? headers = null)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<object>> Add(AppointmentRequest model, string subUrl,
        Dictionary<string, string>? headers = null)
    {
        var clientName = _configuration["HttpClientName:AppointmentClient"];
        var client = _httpClientFactory.CreateClient(clientName ?? "");
        if (headers is not null)
        {
            foreach (var header in headers)
            {
                if (header.Key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
                {
                    var token = header.Value;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                else
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        try
        {
            StringContent json = new(
                JsonSerializer.Serialize(model, new JsonSerializerOptions(JsonSerializerDefaults.Web)),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            var response = await client.PostAsync(subUrl, json);
            if (!response.IsSuccessStatusCode)
                throw new Exception(TaskMessage.ExpMessage);
            var jsonRes = await response.Content.ReadAsStringAsync();
            return new Response<object>()
            {
                StatusCode = 200,
                Message = TaskMessage.Success,
                Data = response.Content
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("An error occur while making http call");
        }
    }

    public Task<RestResponse> Update(AppointmentRequest model, string subUrl,
        Dictionary<string, string>? headers = null)
    {
        throw new NotImplementedException();
    }

    public Task<RestResponse> Delete(long id, string subUrl, Dictionary<string, string>? headers = null)
    {
        throw new NotImplementedException();
    }
}