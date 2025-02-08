using FullStackMon.Models;
using FullStackMon.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullStackMon.Controllers
{
    public class DepartmentController : Controller
    {
        //From DB using ITIContext
        // ITIContext context = new ITIContext();
        IDepartmentRepository DepartmentRepository;
        IEmployeeRepository EmployeeRepository;
        public DepartmentController(IEmployeeRepository empRepo,IDepartmentRepository deptREpo)
        {
            DepartmentRepository = deptREpo;
            EmployeeRepository  = empRepo;
        }

        public IActionResult ShowDEpartments()
        {
            List<Department> depListModel=DepartmentRepository.GetAll();
            return View(depListModel);
        }
        //Department/EmpByDEpartment?DeptId=1
        public IActionResult EmpByDEpartment(int DeptId)
        {
            List<Employee> empList=EmployeeRepository.GetByDeptId(DeptId);
            return Json(empList);
        }


        //Department/index
        [Authorize]//non authorize ==>account/login
        public IActionResult Index()
        {
            List<Department> DeptListModel = DepartmentRepository.GetAll();
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
                DepartmentRepository.Add(deptFromRequest);
                DepartmentRepository.Save();
                return RedirectToAction("Index");
            }
            return View("New", deptFromRequest);//View =>new ,Model =department
            
        }
    }
}
