using Hrms.Lite.Services.IServices;
using Hrms.Lite.Shared.General;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;


public class ServiceBase : IServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    public ServiceBase(IOptions<AppSettings> settings)
    {
        _baseUrl = settings.Value.ApiBaseUrl;
        _httpClient = new HttpClient();
    }

    public async Task<T> Get<T>(string url)
    {
        url = $"{_baseUrl}{url}";
        T result = default(T);

        var response = _httpClient.GetAsync(new Uri(url)).Result;

        response.EnsureSuccessStatusCode();
        await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
        {
            if (x.IsFaulted)
                throw x.Exception;

            result = JsonConvert.DeserializeObject<T>(x.Result);
        });

        return result;
    }

    public async Task<T> PostRequest<T>(string apiUrl, T postObject)
    {
        apiUrl = $"{_baseUrl}{apiUrl}";
        T result = default(T);

        var response = await _httpClient.PostAsync(apiUrl, postObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
        {
            if (x.IsFaulted)
                throw x.Exception;

            result = JsonConvert.DeserializeObject<T>(x.Result);

        });

        return result;
    }

    public async Task<T> PostFormDataAsync<T>(string url, T data)
    {
        url = $"{_baseUrl}{url}";
        var content = new MultipartFormDataContent();
        T result = default(T);

        foreach (var prop in data.GetType().GetProperties())
        {
            var value = prop.GetValue(data);
            if (value is FormFile)
            {
                var file = value as FormFile;
                content.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = prop.Name, FileName = file.FileName };
            }
            else
            {
                content.Add(new StringContent(JsonConvert.SerializeObject(value)), prop.Name);
            }
        }
        var response = await _httpClient.PostAsync(url, content).ConfigureAwait(false);
        await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
        {
            if (x.IsFaulted)
                throw x.Exception;

            result = JsonConvert.DeserializeObject<T>(x.Result);

        });

        return result;
    }
}