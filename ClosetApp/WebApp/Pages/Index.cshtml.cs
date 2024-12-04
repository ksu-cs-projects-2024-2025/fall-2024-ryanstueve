using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebApp.Data;
using WebApp.Models.Domain;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {

        private readonly RealDbContext dbContext;

        public List<ClothingItem> ClothingItems { get; set; }


        public IndexModel(RealDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            ClothingItems = dbContext.ClothingItems.ToList();
        }
    }
}
