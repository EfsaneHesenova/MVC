using FrontToBacktask.DAL;
using FrontToBacktask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBacktask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public WorkController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;     
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Work> works = await _appDbContext.Works.ToListAsync();
            return View(works);
        }
        public IActionResult Delete (int Id)
        {
            Work? deletedWork = _appDbContext.Works.Find(Id);
            if (deletedWork == null) { return NotFound(); }
            else
            {
                _appDbContext.Works.Remove(deletedWork);
                _appDbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            _appDbContext.Works.Add(work);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
