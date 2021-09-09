using Hrms.Lite.Shared.General;
using Hrms.Lite.Shared.Master;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hrms.Lite.Repository.IRepository
{
    public interface ICourseRepository
    {
        Task<IList<Course>> GetList();
        Task<Course> GetDetails(Guid guid);

        Task<ResponseEntity> Save(Course input);
        Task<ResponseEntity> Delete(Guid guid);
    }
}