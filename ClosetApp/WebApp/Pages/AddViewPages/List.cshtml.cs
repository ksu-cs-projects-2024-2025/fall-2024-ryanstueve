using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using WebApp.Data;
using WebApp.Models.Domain;

namespace WebApp.Pages.AddViewPages
{
    public class ListModel : PageModel
    {
        private readonly RealDbContext dbContext;

        public List<ClothingItem> ClothingItems { get; set; }

        public ListModel(RealDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void OnGet()
        {
            ClothingItems = dbContext.ClothingItems.ToList();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
