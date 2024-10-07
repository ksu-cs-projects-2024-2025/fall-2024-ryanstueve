using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebApp.Data;
using WebApp.Models.Domain;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {

        private readonly TestDbContext dbContext;

        public List<TestClothingItem> ClothingItems { get; set; }


        public IndexModel(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            ClothingItems = dbContext.TestClothingItems.ToList();
        }
    }
}
