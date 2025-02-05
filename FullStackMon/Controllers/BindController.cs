using FullStackMon.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullStackMon.Controllers
{
    public class BindController : Controller
    {
        ///cant be static
        ///cant be private
        ///cant overload one case (get | post)
        //Get:Bind/MEthod1
        [HttpGet]
        public IActionResult MEthod1()
        {
            return Content("MEthod1");
        }
        //post:Bind/MEthod1
        [HttpPost]
        public IActionResult MEthod1(int id,string name)
        {
            return Content("MEthod1 id,name");
        }
        /*
         <form action="/Bind/testPrmitive/1" method="get">
              <input name="name">
              //<input name="id">

              <input name="age">
              <input name="Color" >
        <input name="phone[ahmed]">
              <input type="Submit">
        </form>
        ///Bind/testPrmitive/11?name=Ahmed&age=10;   //id found RouteValue
        ///Bind/testPrmitive?name=Ahmed&age=10&id=11&color=red;//id found Query String
        
         */
        //Binding parmeter prmitive (int ,float ,strnig)
        ///bind/testPrimitive?color[1]=red&color[0]=blue
        public IActionResult testPrimitive(string name,int age,int id,string[] color)
        {
            return Content("ok");
        }

        //Collection List,Dict
        //Bind/TestDic?phone[ahmed]=123&phone[mohamed]=456&name=chirs
        public IActionResult TestDic(Dictionary<string,string> Phone,string name)
        {
            
            return Content("ok");
        }

        //Custom Data Type "Class"
        //public IActionResult TestComplex
        //    (int Id,string name,string MAnagerName,List<Employee> Employees, string color)
        /// <summary>
        /// bind/testComplex/100?name=sd&managername=ahmed&
        /// color=red&Employees[0].name=alaa&employees[0].id=1
        public IActionResult TestComplex(Department dept,Employee emp)
        {
            return Content("ok");
        }

    }   
}
