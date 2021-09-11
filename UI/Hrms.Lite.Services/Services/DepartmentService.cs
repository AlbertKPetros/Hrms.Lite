using Hrms.Lite.Services.IServices;
using Hrms.Lite.Shared.General;
using Hrms.Lite.Shared.Master;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hrms.Lite.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly string _baseURL;
        private readonly IServiceBase _httpService;
        public DepartmentService(IServiceBase httpService)
        {
            _baseURL = "department";
            _httpService = httpService;
        }
        public async Task<IEnumerable<Department>> GetList()
        {
            return await _httpService.GetAsync<IEnumerable<Department>>($"{_baseURL}/list");
        }

        Task<Department> IDepartmentService.GetDetails(int id, Guid identifier, string mode)
        {
            return _httpService.GetAsync<Department>($"{_baseURL}/Details?id={id}&identifier={identifier}&mode={mode}");
        }

        Task<ResponseEntity> IDepartmentService.Create(Department input)
        {
            return _httpService.PostAsync<ResponseEntity, Department>($"{_baseURL}/Create", input);
        }

        Task<ResponseEntity> IDepartmentService.CreateWithFile(Department input)
        {
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(input.Logo.OpenReadStream())
            {
                Headers =
                    {
                        ContentLength = input.Logo.Length,
                        ContentType = new MediaTypeHeaderValue(input.Logo.ContentType)
                    }
            }, "Logo", input.Logo.FileName);
            content.Add(new StringContent(input.Name), "Name");
            return _httpService.PostFormDataAsync<ResponseEntity>($"{_baseURL}/CreateWithFile", content);
        }

    }
}
