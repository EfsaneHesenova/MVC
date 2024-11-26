using FrontToBacktask.DAL;
using FrontToBacktask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        
        public async Task<IActionResult> Create()
        {
            ViewBag.Services = _appDbContext.Services;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Work work)
        {
            if (ModelState.IsValid)
            {
                Service? service = _appDbContext.Services.Find(work.ServiceId);

                if (service is not null)
                {
                    await _appDbContext.Works.AddAsync(work);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            
            ViewBag.Services = _appDbContext.Services;
            return View(work);
        }
        
        public ActionResult Update(int? Id)
        {
            Work? work = _appDbContext.Works.Find(Id);
            if (work == null)
            {
                return NotFound();
            }
            return View(nameof(Create), work);
        }


        [HttpPost]
        public ActionResult Update(Work work)
        {
            Work? updatedWork = _appDbContext.Works.AsNoTracking().FirstOrDefault(w => w.Id == work.Id);
            if (updatedWork == null)
            {
                return BadRequest();
            }
            _appDbContext.Works.Update(work);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
