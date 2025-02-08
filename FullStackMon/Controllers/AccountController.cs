using FullStackMon.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FullStackMon.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View("Reister");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel UserFromRequest)
        {
            if(ModelState.IsValid)
            {
                //save Db
            }
            return View("Reister",UserFromRequest);
        }
    }
}
