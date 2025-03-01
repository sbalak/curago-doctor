using System.Diagnostics;
using Doctor.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Doctor.Web.Controllers
{
    public class HomeController : Controller
    {
        private IReferenceService _reference;

        public HomeController(IReferenceService reference)
        {
            _reference = reference;
        }

        public IActionResult Index()
        {
            ViewBag.Specialities = _reference.GetSpecialities().Result.Select(m => new SelectListItem { Value = m.Id.ToString(), Text = m.Name });

            return View();
        }
    }
}
