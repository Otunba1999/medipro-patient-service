using System.Net.Mime;
using System.Text;
using System.Text.Json;
using medipro_patient_service.Application.Interfaces.HttpService;
using Medipro_Patient_Service.Common.Requests;
using Medipro_Patient_Service.Common.Responses;
using Medipro_Patient_Service.Common.Utilities;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Medipro_Patient_Service.Infrastructure.HttpService;

public class EmailService : IHttpService<MailRequest>
{
    private readonly IHttpClientFactory _httpClientFactory = null;
    private readonly IConfiguration _configuration = null;

    public EmailService(
        IHttpClientFactory httpClientFactory, IConfiguration configuration) => (
        _httpClientFactory, _configuration) = (httpClientFactory, configuration);
    
    public Task<List<MailRequest>> GetAll(string subUrl, Dictionary<string, string>? queryParams = null, Dictionary<string, string>? headers = null)
    {
        throw new NotImplementedException();
    }

    public Task<MailRequest> GetById(long id, string subUrl, Dictionary<string, string>? queryParams = null, Dictionary<string, string>? headers = null)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<object>> Add(MailRequest model, string subUrl, Dictionary<string, string>? headers = null)
    {
        var clientName = _configuration["HttpClientName:EmailClient"];
        var client = _httpClientFactory.CreateClient(clientName ?? "");
        try
        {

            StringContent json = new(
                JsonSerializer.Serialize(model, new JsonSerializerOptions(JsonSerializerDefaults.Web)),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            var response = await client.PostAsync(subUrl, json);
            if (!response.IsSuccessStatusCode)
                throw new Exception(TaskMessage.ExpMessage);
            return new Response<object>()
            {
                StatusCode = 200,
                Message = TaskMessage.Success,
                Data = response.Content.ReadAsStringAsync()
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("An error occur while making http call");
        }
    }

    public Task<RestResponse> Update(MailRequest model, string subUrl, Dictionary<string, string>? headers = null)
    {
        throw new NotImplementedException();
    }

    public Task<RestResponse> Delete(long id, string subUrl, Dictionary<string, string>? headers = null)
    {
        throw new NotImplementedException();
    }
}