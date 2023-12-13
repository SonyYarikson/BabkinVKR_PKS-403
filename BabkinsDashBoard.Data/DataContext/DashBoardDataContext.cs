using BabkinsDashBoard.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BabkinsDashBoard.Data.DataContext
{
    public class DashBoardDataContext : DbContext
    {
        public DashBoardDataContext(DbContextOptions<DashBoardDataContext> options) : base (options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
