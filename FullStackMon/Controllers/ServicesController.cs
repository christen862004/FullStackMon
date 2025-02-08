using FullStackMon.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FullStackMon.Controllers
{
    public class ServicesController : Controller
    {
        
        public IActionResult ShowUserData()
        {
            //id ,name ,role
            if (User.Identity.IsAuthenticated == true)
            {
                string name = User.Identity.Name;
                
                //==>request (cookies[idenity])==>User

                Claim IdClaim= 
                    User.Claims.FirstOrDefault(c => c.Type ==ClaimTypes.NameIdentifier);
                return Content($"Welcome {name} id={IdClaim.Value}");
            }
            else
            {
                return Content("Welcome Gust");

            }
        }



        private readonly IDepartmentRepository departmentRepository;

        public ServicesController(IDepartmentRepository departmentRepository)//inject costructor
        {
            this.departmentRepository = departmentRepository;
        }


        public IActionResult Index()//[FromServices]IDepartmentRepository departmentRepository)//inject
        {
            ViewData["Id"] = departmentRepository.Id;
            return View();
        }
    }
}
