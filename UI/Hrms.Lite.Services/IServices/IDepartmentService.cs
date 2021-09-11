using Hrms.Lite.Shared.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hrms.Lite.Services.IServices
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<Department>> GetList();
    }
}
