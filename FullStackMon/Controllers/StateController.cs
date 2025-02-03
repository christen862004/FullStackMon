using Microsoft.AspNetCore.Mvc;

namespace FullStackMon.Controllers
{
    public class StateController : Controller
    {
        int counter;//StateMangement app all action view

        public IActionResult SetCookie() {
            //session Cookie
            HttpContext.Response.Cookies.Append("Name", "Doha");
            //Presistent Cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddHours(1); ;
            HttpContext.Response.Cookies.Append("Age", "20", options);

            return Content("Cooie Saved");

        }
        //any controller any action 
        public IActionResult GetCookie()
        {
            //logic
            string name=  HttpContext.Request.Cookies["Name"];
            string age=  HttpContext.Request.Cookies["Age"];
            return Content($"name={name}\t age={age}");
        }








        public IActionResult setSession()//string name,int s)
        {
            //serialize object to json{namr:ere,age:10}
            HttpContext.Session.SetString("Name", "AbdelRahman");
            HttpContext.Session.SetInt32("Salary",200000);

            return Content("Session Saved");
        }
        public IActionResult getSession()
        {
            //logic ==>need read from session
            string name= HttpContext.Session.GetString("Name");
            int? salary= HttpContext.Session.GetInt32("Salary");
            return Content($"Get Session name{name} \t salary{salary}");
        }


        
    }
}
