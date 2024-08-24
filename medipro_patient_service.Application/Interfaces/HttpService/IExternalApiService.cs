using RestSharp;

namespace medipro_patient_service.Application.Interfaces.HttpService;
/// <summary>
/// A service use for making external api calls.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IExternalApiService<T> where T : class
{
   /// <summary>
   /// make a get request to the api and return some data if available.
   /// </summary>
   /// <param name="subUrl">receives the url of the api</param>
   /// <param name="queryParams">receives the query parameters</param>
   /// <param name="headers">receives the headers for the request</param>
   /// <returns>returns api response</returns>
   Task<List<T>> GetAll(string subUrl, Dictionary<string, string>? queryParams = null,
      Dictionary<string, string>? headers = null);

   /// <summary>
   /// get a single a data from the api.
   /// </summary>
   /// <param name="id">receives the id of the data to be deleted</param>
   /// <param name="subUrl">receives the url of the api</param>
   /// <param name="queryParams">receives the query parameters</param>
   /// <param name="headers">receives the headers for the request</param>
   /// <returns>returns a single data from the api.</returns>
   Task<T> GetById(long id, string subUrl, Dictionary<string, string>? queryParams = null,
      Dictionary<string, string>? headers = null);

   /// <summary>
   /// make a post request to the api.
   /// </summary>
   /// <param name="model">receives the data to be send across with the request.</param>
   /// <param name="subUrl">receives the url of the api</param>
   /// <param name="headers">receives the headers for the request</param>
   /// <returns>returns a rest response from the request.</returns>
   Task<RestResponse> Add(T model, string subUrl, Dictionary<string, string>? headers = null);
   /// <summary>
   /// make a update request to the api.
   /// </summary>
   /// <param name="model">receives the data to be send across with the request.</param>
   /// <param name="subUrl">receives the url of the api</param>
   /// <param name="headers">receives the headers for the request</param>
   /// <returns>returns a rest response from the request.</returns>
   Task<RestResponse> Update(T model, string subUrl, Dictionary<string, string>? headers = null);
   /// <summary>
   /// make a delete request to the api.
   /// </summary>
   /// <param name="id">receives the id of the data to be deleted.</param>
   /// <param name="subUrl">receives the url of the api</param>
   /// <param name="headers">>receives the headers for the request</param>
   /// <returns>returns a rest response from the request.</returns>
   Task<RestResponse> Delete(long id, string subUrl, Dictionary<string, string>? headers = null);
   
}