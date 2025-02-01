using FullStackMon.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullStackMon.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL=new StudentBL();
        //student/All
        public IActionResult All()
        {
            List<Student> studentListModel=
                studentBL.GetAll();//get data from model
            return View("AllStudent", studentListModel);//send data view
        }
        //Views/Student/AllStudent
        //Views/Shared/AllStudent
        public IActionResult Details(int id)
        {
            Student stdModel= studentBL.GetByID(id);
            return View("DEtails",stdModel);
        }
    }
}
