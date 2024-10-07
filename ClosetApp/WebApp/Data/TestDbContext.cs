using Microsoft.EntityFrameworkCore;
using WebApp.Models.Domain;

namespace WebApp.Data
{
    public class TestDbContext :DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) :base(options)
        {
            
        }

        public DbSet<TestClothingItem> TestClothingItems { get; set; }
    }
}
