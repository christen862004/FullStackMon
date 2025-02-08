using FullStackMon.Models;
using FullStackMon.Repository;
using FullStackMon.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace FullStackMon.Controllers
{
    //EmployeeController depend all ITIContext (tigh couple)
    
    public class EmployeeController : Controller
    {
        IEmployeeRepository EmployeeRepository;//DIP & IOC
        IDepartmentRepository DepartmentRepository;

        //depency inject ControllerFactory
        public EmployeeController
            (IEmployeeRepository empRepo,IDepartmentRepository deptrep)//inject "ask"
        {
            EmployeeRepository =empRepo;
            
            DepartmentRepository = deptrep;
        }

        public IActionResult EmpCardPartial(int id)
        {
            Employee empModel =  EmployeeRepository.GetById(id);

            return PartialView("_EmpCardPartial",empModel);
        } 
        
        public IActionResult CheckSalary(int Salary,string JobTitle)
        {
            if (JobTitle == "a")
            {
                if(Salary<50000 && Salary > 40000)
                {
                    return Json(true);
                }
            }
            if (JobTitle == "b")
            {
                if (Salary < 40000 && Salary > 30000)
                {
                    return Json(true);
                }
            }
            return Json(false);
           
        }

        public IActionResult Index()
        {
            List<Employee> EmpsModel = EmployeeRepository.GetAll();
               
            return View("Index", EmpsModel);
        }
        //[Authorize]
        public IActionResult New()
        {
            ViewData["DeptList"] =DepartmentRepository.GetAll();
            return View("New");
        }

        [HttpPost]//write endpoint in url
        [ValidateAntiForgeryToken]//make sure reqquest internal with valid token
        public IActionResult SaveNew(Employee EmpFromRequest)
        {
           if(ModelState.IsValid==true)
            {
                //if (EmpFromRequest.DepartmentId != 0)
                try
                {
                    EmployeeRepository.Add(EmpFromRequest);
                    EmployeeRepository.Save();
                    return RedirectToAction("Index");
                }catch  (Exception ex)
                {
                    //send exception as error in modelstate
                    //  ModelState.AddModelError("DepartmentId", "Please Select DEpartment");
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
            }
            ViewData["DeptList"] = DepartmentRepository.GetAll();//Dont FORGET IT
            return View("New", EmpFromRequest);
        }




        public IActionResult Edit(int id)
        {
            //get data ==>mapping ==>send data to view
            Employee EmpModel = EmployeeRepository.GetById(id);
            List<Department> deptList=DepartmentRepository.GetAll();

            EmployeeWithDepartmentsListViewModel empVM = 
                new EmployeeWithDepartmentsListViewModel();
            //mapping from db set vm "automapper"
            empVM.Id = EmpModel.Id;
            empVM.Name = EmpModel.Name;
            empVM.Address = EmpModel.Address;
            empVM.JobTitle = EmpModel.JobTitle;
            empVM.ImageUrl = EmpModel.ImageUrl;
            empVM.Salary = EmpModel.Salary;
            empVM.DepartmentId = EmpModel.DepartmentId;
            empVM.DepartmentList = deptList;
            
            return View("Edit", empVM);//View=>Edit ,Model =Employee + List<department>
        }
        
        [HttpPost]
   
        public IActionResult SaveEdit(EmployeeWithDepartmentsListViewModel empFromRequest)
        {
            //if (Request.Method == "Post")
            //{

            //}else[
            if (empFromRequest.Name != null)//Validation
            {
                //context.Update(empFromRequest);
                

                #region Old EntityFramowk update
                Employee empFromDb =EmployeeRepository.GetById(empFromRequest.Id);
                empFromDb.Name = empFromRequest.Name;
                empFromDb.JobTitle = empFromRequest.JobTitle;
                empFromDb.Address = empFromRequest.Address;
                empFromDb.ImageUrl = empFromRequest.ImageUrl;
                empFromDb.Salary = empFromRequest.Salary;
                empFromDb.DepartmentId = empFromRequest.DepartmentId;
                EmployeeRepository.Save();
                #endregion
                return RedirectToAction("Index");
            }

            empFromRequest.DepartmentList = DepartmentRepository.GetAll();
            return View("Edit", empFromRequest);
        }


        //Employee/TestRoute?crsId=10&crsName=C#
        public IActionResult TestRoute(int crsId,string crsNAme)
        {
            return Content("Ok");
        }
        public IActionResult Delete(int id)
        {
            Employee EmpModel = EmployeeRepository.GetById(id);
            return View("Delete", EmpModel);
        }
        
        
        //Employeee/Details/1
        public IActionResult Details(int id)
        {
            #region Extra data need to send from backend to frontend
            string msg = "Hello";
            int temp = 10;
            List<string> branches= new List<string>();
            branches.Add("Alex");
            branches.Add("Cairo");
            branches.Add("Assiut");
            branches.Add("MEnia");
            branches.Add("Monofia");
            string color = "red";
         

            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["clr"] = "red";
            ViewData["br"] = branches;
            ViewBag.xyz = "hello";
            ViewBag.clr = "blue";
            #endregion
            Employee EmpModel =EmployeeRepository.GetById(id);
            return View("Details", EmpModel); //view = DEtails ,Model =Employee
        }//end of request


        public IActionResult DetailsVM(int id)
        {
            //Extra data need to send from backend to frontend
            string msg = "Hello";
            int temp = 10;
            List<string> branches = new List<string>();
            branches.Add("Alex");
            branches.Add("Cairo");
            branches.Add("Assiut");
            branches.Add("MEnia");
            branches.Add("Monofia");
            string color = "red";

            Employee EmpModel = EmployeeRepository.GetById(id);

            //create ViewModel Object
            EmployeeWithClrMsgBranchesTempViewModel EmpViewModel = 
                new EmployeeWithClrMsgBranchesTempViewModel();
            //fill data in vm
            EmpViewModel.EmpName = EmpModel.Name;
            EmpViewModel.EmpId = EmpModel.Id;
            EmpViewModel.Msg = msg;
            EmpViewModel.Color ="green";
            EmpViewModel.Temp =28;
            EmpViewModel.Branches =branches;
            
            //send ViewModel To FrontEnd

            return View("DetailsVM", EmpViewModel); //view = DEtails ,Model =EmployeeWithClrMsgBranchesTempViewModel
        }

        
    }
}
