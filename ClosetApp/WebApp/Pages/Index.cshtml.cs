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
        //create a button to save an outfit. You would write a function that gets the current n values of
        //both the top and the bottom outfits. you would then create two lists that include all of the
        //top outfits and all of the bottom outfits. then you would use the two numbers to get the outfits
        //you would then add those to the outfits table.
    }
}
