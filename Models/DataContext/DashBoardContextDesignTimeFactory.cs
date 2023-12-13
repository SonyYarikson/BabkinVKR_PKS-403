using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Models.DataContext
{
    public class DashBoardContextDesignTimeFactory : IDesignTimeDbContextFactory<DashBoardDataContext>
    {
        public DashBoardDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DashBoardDataContext>();
            optionsBuilder.UseNpgsql(
                "host=localhost;port=5432;database=BabkinsDashBoardDB;username=admin;password=root");

            var context = new DashBoardDataContext(optionsBuilder.Options);
            //context.Database.Migrate();

            return context;
        }
    }
}
