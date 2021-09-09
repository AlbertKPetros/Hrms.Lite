using Hrms.Lite.Shared.General;
using Hrms.Lite.Shared.Master;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hrms.Lite.Repository.IRepository
{
    public interface IDepartmentRepository
    {
        Task<IList<Department>> GetList();
        Task<Department> GetDetails(Guid guid);
        Task<ResponseEntity> Save(Department input);
        Task<ResponseEntity> Delete(Guid guid);
    }
}
