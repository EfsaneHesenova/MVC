using Microsoft.AspNetCore.Mvc;

namespace FrontToBacktask.Controllers
{
    public class WorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
