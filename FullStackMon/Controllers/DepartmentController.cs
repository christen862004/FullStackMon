using FullStackMon.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullStackMon.Controllers
{
    public class DepartmentController : Controller
    {
        //From DB using ITIContext
        ITIContext context = new ITIContext();
        //Department/index
        public IActionResult Index()
        {
            List<Department> DeptListModel=
                context.Department.ToList();
            return View("Index",DeptListModel);//index ,Model ==>List<Department>
        }
    }
}
