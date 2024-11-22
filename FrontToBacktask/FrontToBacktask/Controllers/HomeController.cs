using FrontToBacktask.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBacktask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            


            return View();
        }
    }
}
