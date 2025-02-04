﻿using FullStackMon.Models;
using FullStackMon.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FullStackMon.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Employee> EmpsModel=
                context.Employee.ToList();
            return View("Index", EmpsModel);
        }
        public IActionResult Edit(int id)
        {
            Employee EmpModel=
                context.Employee.FirstOrDefault(e=>e.Id==id);
            List<Department> deptList=context.Department.ToList();

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
            if (empFromRequest.Name != null)
            {
                //context.Update(empFromRequest);
                

                #region Old EntityFramowk update
                Employee empFromDb =
                    context.Employee.FirstOrDefault(e => e.Id == empFromRequest.Id);
                empFromDb.Name = empFromRequest.Name;
                empFromDb.JobTitle = empFromRequest.JobTitle;
                empFromDb.Address = empFromRequest.Address;
                empFromDb.ImageUrl = empFromRequest.ImageUrl;
                empFromDb.Salary = empFromRequest.Salary;
                empFromDb.DepartmentId = empFromRequest.DepartmentId;
                context.SaveChanges();
                #endregion
                return RedirectToAction("Index");
            }

            empFromRequest.DepartmentList = context.Department.ToList();
            return View("Edit", empFromRequest);
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

        
    }
}
