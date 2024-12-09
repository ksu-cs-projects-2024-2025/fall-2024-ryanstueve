using Microsoft.EntityFrameworkCore;
using WebApp.Models.Domain;

namespace WebApp.Data
{
    //an old test database
    public class TestDbContext :DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) :base(options)
        {
            
        }

        public DbSet<TestClothingItem> ClothingItems { get; set; }
    }
}
