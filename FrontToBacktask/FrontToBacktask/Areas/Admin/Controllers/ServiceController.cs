using FrontToBacktask.DAL;
using FrontToBacktask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBacktask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ServiceController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> services = await _appDbContext.Services.ToListAsync();
            return View(services);
        }
        public IActionResult Delete(int Id)
        {
            Service? deletedService = _appDbContext.Services.Find(Id);
            if (deletedService == null)
            {
                return NotFound();
            }
            else
            {
                _appDbContext.Services.Remove(deletedService);
                _appDbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
            
        }
        public ActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _appDbContext.Services.Add(service);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? Id)
        {
            Service? service = _appDbContext.Services.Find(Id);
            if (service == null)
            {
                return NotFound();
            }
            return View(nameof(Create),service);
        }


        [HttpPost]
        public IActionResult Update (Service service)
        {
            Service? updatedService = _appDbContext.Services.AsNoTracking().FirstOrDefault(service => service.Id == service.Id);
            if (updatedService == null)
            {
                return BadRequest();
            }
            _appDbContext.Services.Update(service);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
