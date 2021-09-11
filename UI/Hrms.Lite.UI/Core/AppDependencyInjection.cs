using Hrms.Lite.Services.IServices;
using Hrms.Lite.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hrms.Lite.UI.Core
{
    public static class AppDependencyInjection
    {
        public static void AddDependencyInjectionServices(this IServiceCollection services)
        {
            #region General
            services.AddTransient<IServiceBase, ServiceBase>();
            #endregion

            #region Master
            services.AddTransient<IDepartmentService, DepartmentService>();
            #endregion

            #region Databank
            #endregion
        }
    }
}
