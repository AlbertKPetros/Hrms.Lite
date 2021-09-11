using Microsoft.AspNetCore.Http;
using System;

namespace Hrms.Lite.Shared.Master
{
    public class Department
    {
        public Guid UniqueID { get; set; }
        public string Name { get; set; }
        public IFormFile Logo { get; set; }
    }
}
