using FrontToBacktask.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontToBacktask.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Service> Services { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Work>()
                .HasOne(s => s.Service)
                .WithMany(s => s.Works)
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

