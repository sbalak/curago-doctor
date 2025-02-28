using Doctor.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.Web.Controllers
{
    public class AccountController : Controller
    {
        private IStaffService _staff;

        public AccountController(IStaffService staff)
        {
            _staff = staff;
        }

        //public IActionResult Register()
        //{
        //    return View();
        //}

        public async Task<JsonResult> RegisterInterest(string firstName, string lastName, string phone, string email)
        {
            var response = await _staff.CreateInterest(firstName, lastName, phone, email);
            return Json(response);
        } 
    }
}
