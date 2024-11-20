using Microsoft.AspNetCore.Mvc;

namespace SchoolManagmentMVCtask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
