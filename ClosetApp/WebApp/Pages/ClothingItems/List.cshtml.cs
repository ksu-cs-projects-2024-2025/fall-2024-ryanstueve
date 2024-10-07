using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using WebApp.Data;
using WebApp.Models.Domain;

namespace WebApp.Pages.ClothingItems
{
    public class ListModel : PageModel
    {
        private readonly TestDbContext dbContext;

        public List<TestClothingItem> ClothingItems { get; set; }

        public ListModel(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void OnGet()
        {
            ClothingItems = dbContext.TestClothingItems.ToList();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
