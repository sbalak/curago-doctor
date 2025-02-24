using Microsoft.AspNetCore.Mvc;

namespace Doctor.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
