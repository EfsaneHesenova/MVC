using Microsoft.EntityFrameworkCore;
using Proniatask.Models;

namespace Proniatask.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<SliderItem> SliderItems { get; set; }
    }
}
