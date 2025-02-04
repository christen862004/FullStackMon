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

        public IActionResult New()
        {
            return View("New");//Model =null
        }

        //Department/SaveNew?Name= &ManagerName=
        //CAn handel request Get |Post
        [HttpPost]//attribute "Filter"
        public IActionResult SaveNew(Department deptFromRequest)
        {
            //add new Department
            if (deptFromRequest.Name != null && deptFromRequest.ManagerName != null)
            {
                context.Add(deptFromRequest);
                context.SaveChanges();//exeption
                                        //return RedirectToAction("Index","Departemrnt",new {id=99});
                return RedirectToAction("Index");
            }
            return View("New", deptFromRequest);//View =>new ,Model =department
            
        }
    }
}
