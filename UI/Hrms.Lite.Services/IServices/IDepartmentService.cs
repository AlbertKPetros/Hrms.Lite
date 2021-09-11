using Hrms.Lite.Shared.General;
using Hrms.Lite.Shared.Master;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hrms.Lite.Services.IServices
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<Department>> GetList();
        public Task<Department> GetDetails(int id, Guid identifier, string mode);
        public Task<ResponseEntity> Create(Department input);
        public Task<ResponseEntity> CreateWithFile(Department input);
    }
}
