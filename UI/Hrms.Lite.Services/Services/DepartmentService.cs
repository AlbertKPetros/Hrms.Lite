using Hrms.Lite.Services.IServices;
using Hrms.Lite.Shared.Master;
using System.Collections.Generic;
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
        public Task<IEnumerable<Department>> GetList()
        {
            return _httpService.Get<IEnumerable<Department>>($"{_baseURL}/list");
        }
    }
}
