using Microsoft.AspNetCore.Mvc;
using Proniatask.DAL;
using Proniatask.Models;

namespace Proniatask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult Index()
        {
            /*SliderItem sliderItem = new SliderItem()
            {
                Title = "New Plant",
                ShortDesc = "Pronia, With 100% Natural, Organic & Plant Shop.",
                İmagePath = "1-1-524x617.png",
                Offer = 65
            };
            SliderItem sliderItem2 = new SliderItem()
            {
                Title = "New Plant",
                ShortDesc = "Pronia, With 100% Natural, Organic & Plant Shop.",
                İmagePath = "1-2-524x617.png",
                Offer = 65
            };

            _context.SliderItems.Add(sliderItem);
            _context.SliderItems.Add(sliderItem2);
            _context.SaveChanges();*/

            IEnumerable<SliderItem> sliderItems = _context.SliderItems.ToList();

            return View(sliderItems);
        }
    }
}
