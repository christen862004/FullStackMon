using Microsoft.AspNetCore.Mvc;

namespace FullStackMon.Controllers
{
    public class RouteController : Controller
    {
        //route/Method1?name=Ahemd (default)
        //r1?name=Ahmed            (route1)
        
        //r1/sherin/10
        [Route("r1/{name}/{age?}")]//prevent any othre route
        public IActionResult MEthod1(string name,int age)
        {
            return Content("Method1");
        }
        //route/Method2
        //r2
        public IActionResult MEthod2()
        {
            return Content("Method2");

        }
    }
}
