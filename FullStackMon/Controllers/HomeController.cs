using FullStackMon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FullStackMon.Controllers
{
    /*handel request  == >build response
     cactch reqquest
     get model
     send view 
     */
    public class HomeController : Controller
    {
        /* Action
         1) must be public
         2) cant be static
         3) cant be overload
         */
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /*
         action return type:
        1)content ==> ContentResult ==>Content()
        2)view    ==> ViewResult    ==>View()
        3)Json    ==> JsonResut    ==> Json
        4)file    ==> fileREsult
        5)Empty   ==> EmptyResult
        6)notFound==> NotFoundResult
        7)UnAuthorize=>UnauthrReuslt
        8)..
         */



        //MEthod = >action  url ==>Endpoint /home/first
        public ContentResult First()
        {
            //logic...
            //decalre 
            ContentResult result = new ContentResult();
            //set data
            result.Content = "Hello World from MVC :)";
            //return 
            return result;
        }
        //home/ShowView
        public ViewResult ShowView()
        {
            //logic
            //decalre
            ViewResult result = new ViewResult();
            //set 
            result.ViewName = "View1";
            //REsturn
            return result;
        }

        //action ==>number : odd ==>string ,even ==>view
        //class/MEthod?num=10&name=ahmed&id=1   [query String]
        //class/method/1?num=10&name=ahmed
        public IActionResult ShowMix(int num,string name,int id)
        {            
            if (num % 2 == 0)
            {
                return View("View1");
            }
            else
            {
                return Content("Hello From Mix Action :)");
            }
        }
        //[NonAction]//no endpoint
        //public ViewResult View(string nameView)
        //{
        //    ViewResult result = new ViewResult();
        //    //set 
        //    result.ViewName = nameView;
        //    //REsturn
        //    return result;
        //}


        //home/index "endpoint""
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
