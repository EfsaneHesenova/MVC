using FrontToBacktask.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontToBacktask.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Form> Forms { get; set; }
    }
}

