using FullStackMon.Models;
using FullStackMon.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FullStackMon.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        //int counter = 0;
        public EmployeeController()
        {
            
        }
        //Employeee/Details/1
        public IActionResult Details(int id)
        {
            //Extra data need to send from backend to frontend
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

            Employee EmpModel=context.Employee.FirstOrDefault(x => x.Id == id);
            return View("Details", EmpModel); //view = DEtails ,Model =Employee
        }


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

            Employee EmpModel = context.Employee.FirstOrDefault(x => x.Id == id);

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

        public IActionResult Index()
        {
            return Content("Indexx");
        }
    }
}
