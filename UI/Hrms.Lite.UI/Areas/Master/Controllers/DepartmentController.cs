using Hrms.Lite.Services.IServices;
using Hrms.Lite.Shared.Master;
using Microsoft.AspNetCore.Mvc;
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

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department input)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateWithFile(Department input)
        {
            return RedirectToAction("Index");
        }
    }
}
