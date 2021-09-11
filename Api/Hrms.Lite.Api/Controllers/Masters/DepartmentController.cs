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
        public async Task<IActionResult> GetDetails(int id, Guid identifier, string mode)
        {
            return Ok(await _repo.GetDetails(identifier));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Department input)
        {
            return Ok(await _repo.Save(input));
        }

        [HttpPost("CreateWithFile")]
        public async Task<IActionResult> CreateWithFile([FromForm] Department input)
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
