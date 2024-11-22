using Microsoft.AspNetCore.Mvc;

namespace FrontToBacktask.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
