using Microsoft.AspNetCore.Mvc;
using SchoolManagmentMVCtask.Models;

namespace SchoolManagmentMVCtask.Controllers
{
    public class GroupController : Controller
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
            List<Group> groups = new List<Group>() { group, group2 };
            return View(groups);
        }
    }
}
