using Microsoft.AspNetCore.Mvc;
using SchoolManagmentMVCtask.Models;


namespace SchoolManagmentMVCtask.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            Group group = new Group()
            {
                Id = 1,
                Name = "A"
            };
            Group group2 = new Group()
            {
                Id = 2,
                Name = "B"
            };

            Teacher teacher = new Teacher()
            {
                Id = 1,
                FirstName = "Mehemmed",
                LastName = "Xelilov",
                Group = group

            };
            Teacher teacher2 = new Teacher()
            {
                Id = 2,
                FirstName = "Xalide",
                LastName = "Hesenova",
                Group = group2

            };
            List<Teacher> teachers = new List<Teacher>() { teacher, teacher2 };
            return View(teachers);
        }

    }
}
