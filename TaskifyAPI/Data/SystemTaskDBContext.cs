using Microsoft.EntityFrameworkCore;
using TaskifyAPI.Models;

namespace TaskifyAPI.Data
{
    public class SystemTaskDBContext : DbContext
    {
        public SystemTaskDBContext(DbContextOptions<SystemTaskDBContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
