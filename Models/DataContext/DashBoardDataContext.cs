using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataContext
{
    public class DashBoardDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Board> Boards{ get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Row> Rows { get; set; }

        public DashBoardDataContext(DbContextOptions<DashBoardDataContext> options) : base(options)
        {
        }

        public static DbContextOptions<DashBoardDataContext> _options;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public void Migrate() => this.Migrate();

    }
}
