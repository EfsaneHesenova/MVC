using Microsoft.AspNetCore.Mvc;
using SchoolManagmentMVCtask.Models;

namespace SchoolManagmentMVCtask.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Group studentGroup = new Group()
            {
                Id = 1,
                Name = "AB205"
            };
            Student student = new Student()
            {
                Id = 1,
                FirstName = "Efsane",
                LastName = "Hesenova",
                Email = "afsanaah23@",
                Group = studentGroup
            };
            Student student2 = new Student()
            {
                Id = 1,
                FirstName = "Yusif",
                LastName = "Hesenov",
                Email = "yusiff23@",
                Group = studentGroup
            };

            List<Student> students = new List<Student>() { student, student2 };

            return View(students);
        }
    }
}
