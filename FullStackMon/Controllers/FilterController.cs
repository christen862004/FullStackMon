using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FullStackMon.Filtters;

namespace FullStackMon.Controllers
{
    //[Authorize]
   // [HandelError]
    public class FilterController : Controller
    {
        //[HandelError]
        [Authorize]
        public IActionResult Index()
        {

            throw new Exception("Index Action Fire Exception");
        }

        public IActionResult Index2()
        {
            throw new Exception("Index2 Action Fire Exception");
            return View();
        }
        
     //   [AllowAnonymous]//default filter
        public IActionResult Index3()
        {
            return View();
        }
    }
}
