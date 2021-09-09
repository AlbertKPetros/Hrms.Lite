using Hrms.Lite.Repository.IRepository;
using Hrms.Lite.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Hrms.Lite.Api.Core
{
    public static class AppDependencyInjection
    {
        public static void AddDependencyInjectionServices(this IServiceCollection services)
        {
            #region Master
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            #endregion

            #region Databank
            #endregion
        }
    }
}
