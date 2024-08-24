using System.Net;
using System.Net.Http.Headers;
using medipro_patient_service.Application.Interfaces.HttpService;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace medipro_patient_service.Infrastructure.HttpService;

public class ExternalApiService<T> : IExternalApiService<T> where T: class
{
    private readonly RestClient _restClient;
    private readonly IConfiguration _configuration;

    public ExternalApiService(IConfiguration configuration)
    {
        _configuration = configuration;
        _restClient = new RestClient(_configuration["ExternalApi:BaseUrl"] ?? string.Empty);
    }

    public async Task<List<T>> GetAll(string subUrl, Dictionary<string, string>? queryParams = null, Dictionary<string, string>? headers = null)
    {
        var request = new RestRequest(subUrl)
        {
            RequestFormat = DataFormat.Json
        };
        // Add query parameter
        if (queryParams is not null)
        {
            foreach (var param in queryParams)
                request.AddQueryParameter(param.Key, param.Value);
        }
        // Add headers
        if (headers is not null)
        {
            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);
        }

        var response = await _restClient.ExecuteAsync<List<T>>(request);
        if (response.StatusCode is not HttpStatusCode.OK)
            throw new Exception($"Error calling external api: {response.ErrorMessage}");
        
        return response.Data!;
    }

    public async Task<T> GetById(long id, string subUrl, Dictionary<string, string>? queryParams = null, Dictionary<string, string>? headers = null)
    {
        var request = new RestRequest($"{subUrl}/{id}")
        {
            RequestFormat = DataFormat.Json
        };
        // Add headers
        if (headers is not null)
        {
            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);
        }

        var response = await _restClient.ExecuteAsync<T>(request);
        if(response.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Error calling external api: {response.ErrorMessage}");
        
        return response.Data!;
    }

    public async Task<RestResponse> Add(T model, string subUrl, Dictionary<string, string>? headers = null)
    {
        var request = new RestRequest(subUrl, Method.Post);
        request.AddJsonBody(model);
        //Add headers
        if (headers != null)
        {
            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);
        }

        var response = await _restClient.ExecuteAsync(request);
        if(response.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Error calling external api: {response.ErrorMessage}");
        
        return response;
    }

    public async Task<RestResponse> Update(T model, string subUrl, Dictionary<string, string>? headers = null)
    {
        var request = new RestRequest(subUrl, Method.Put){RequestFormat = DataFormat.Json};
        request.AddJsonBody(model);
        //Add headers
        if (headers != null)
        {
            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);
        }

        var response = await _restClient.ExecuteAsync(request);
        if(response.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Error calloing external api: {response.ErrorMessage}");
        
        return response;
    }

    public async Task<RestResponse> Delete(long id, string subUrl, Dictionary<string, string>? headers = null)
    {
        var request = new RestRequest($"{subUrl}/{id}", Method.Delete);
        //Add headers
        if (headers != null)
        {
            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);
        }
        var response = await _restClient.ExecuteAsync(request);
        if(response.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Error calloing external api: {response.ErrorMessage}");
        
        return response;
    }
}