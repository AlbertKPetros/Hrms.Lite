using System.Threading.Tasks;

namespace Hrms.Lite.Services.IServices
{
    public interface IServiceBase
    {
        Task<T> Get<T>(string url);
        Task<T> PostRequest<T>(string apiUrl, T postObject);
        Task<T> PostFormDataAsync<T>(string url, T data);

    }
}
