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

        [HttpPost]
        public async Task<JsonResult> Register(string firstName, string lastName, string phone, int experience, int primarySpecialityId, int? secondarySpecialityId = null)
        {
            var staff = await _staff.Create(firstName, lastName, phone, experience, primarySpecialityId, secondarySpecialityId);
            return Json(staff == null ? false : true);
        } 
    }
}
