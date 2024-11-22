using Microsoft.AspNetCore.Mvc;

namespace FrontToBacktask.Controllers
{
    public class WorkSingleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
