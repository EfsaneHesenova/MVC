using FrontToBacktask.DAL;
using FrontToBacktask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FrontToBacktask.Controllers
{
    public class WorkController : Controller
    {
        private readonly AppDbContext _context;
        public WorkController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
       
            
            IEnumerable < Work > works = _context.Works.ToList();
            return View(works);
        }
    }
}
