using Hrms.Lite.Repository.IRepository;
using Hrms.Lite.Shared.General;
using Hrms.Lite.Shared.Master;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hrms.Lite.Repository.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public DepartmentRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<IList<Department>> GetList()
        {
            await Task.Delay(1000);
            return new List<Department>();
        }

        public async Task<Department> GetDetails(Guid guid)
        {
            /*Remove this delay, just for mocking async task*/
            await Task.Delay(1000);
            return new Department();
        }

        public async Task<ResponseEntity> Save(Department input)
        {
            /*Remove this delay, just for mocking async task*/
            await Task.Delay(1000);
            return new ResponseEntity("Saved/Updated successfully", true);
        }

        public async Task<ResponseEntity> Delete(Guid guid)
        {
            await Task.Delay(1000);
            return new ResponseEntity("Saved/Updated successfully", true);
        }
    }
}
