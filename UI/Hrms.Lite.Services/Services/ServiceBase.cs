using Hrms.Lite.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;


public class ServiceBase : IServiceBase
{

    public async Task<T> Get<T>(string url)
    {
        T result = default(T);
        using (var httpClient = new HttpClient())
        {
            var response = httpClient.GetAsync(new Uri(url)).Result;

            response.EnsureSuccessStatusCode();
            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);
            });
        }

        return result;
    }

    public async Task<T> PostRequest<T>(string apiUrl, T postObject)
    {
        T result = default(T);

        using (var client = new HttpClient())
        {
            var response = await client.PostAsync(apiUrl, postObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);

            });
        }

        return result;
    }
}