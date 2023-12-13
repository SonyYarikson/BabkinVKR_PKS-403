using Models.DataContext;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var context = new DashBoardContextDesignTimeFactory().CreateDbContext(new string[] {""});
            context.Database.EnsureDeleted ();
        }
    }
}