using FullStackMon.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FullStackMon.Controllers
{
    public class ServicesController : Controller
    {
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
