﻿using System.Net.Http;
using System.Threading.Tasks;

namespace Hrms.Lite.Services.IServices
{
    public interface IServiceBase
    {
        Task<T> GetAsync<T>(string url);
        Task<TResponse> PostAsync<TResponse, TData>(string apiUrl, TData postObject);
        Task<TResponse> PostFormDataAsync<TResponse>(string url, MultipartFormDataContent data);

    }
}
