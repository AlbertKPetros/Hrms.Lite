using Hrms.Lite.Services.IServices;
using Hrms.Lite.Shared.Master;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hrms.Lite.UI.Areas.Master.Controllers
{
    [Area("Master")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _service.GetList());
        }

        public async Task<ActionResult> Details(int id, Guid identifier, string mode)
        {
            return View(await _service.GetDetails(id, identifier, mode));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Department input)
        {
            var response = await _service.Create(input);
            return RedirectToAction("Index");
        }

        public ActionResult CreateWithFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateWithFile(Department input)
        {
            var response = await _service.CreateWithFile(input);
            return RedirectToAction("Index");
        }
    }
}
