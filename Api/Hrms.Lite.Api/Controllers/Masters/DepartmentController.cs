using Hrms.Lite.Repository.IRepository;
using Hrms.Lite.Shared.Master;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Hrms.Lite.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _repo;
        public DepartmentController(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _repo.GetList());
        }

        [HttpGet("Details")]
        public async Task<IActionResult> GetDetails(Guid guid)
        {
            return Ok(await _repo.GetDetails(guid));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Department input)
        {
            return Ok(await _repo.Save(input));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid guid)
        {
            return Ok(await _repo.Delete(guid));
        }
    }
}
