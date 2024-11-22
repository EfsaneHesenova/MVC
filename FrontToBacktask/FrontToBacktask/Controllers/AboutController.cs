using FrontToBacktask.DAL;
using FrontToBacktask.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBacktask.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult Index()
        {
            /*TeamMember tm1 = new TeamMember()
            {
                Name = "John Doe",
                Description = "Business Development",
                MainImageUrl = "team-01.jpg",
                CreatedDate = DateTime.Now
            };
            TeamMember tm2 = new TeamMember()
            {
                Name = "Jane Doe",
                Description = "Media Development",
                MainImageUrl = "team-02.jpg",
                CreatedDate = DateTime.Now
            };
            TeamMember tm3 = new TeamMember()
            {
                Name = "Sam",
                Description = "Developer",
                MainImageUrl = "team-03.jpg",
                CreatedDate = DateTime.Now
            };

            _context.TeamMembers.Add(tm1);
            _context.TeamMembers.Add(tm2);
            _context.TeamMembers.Add(tm3);
            _context.SaveChanges();*/

            IEnumerable<TeamMember> teamMembers = _context.TeamMembers.ToList();

          

            return View(teamMembers);
        }
    }
}
