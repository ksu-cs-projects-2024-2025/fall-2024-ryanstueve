using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.Domain;

namespace WebApp.Pages.ClothingItems
{
    [Authorize]
    public class ListModel : PageModel
    {
        private readonly RealDbContext dbContext;

        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUser? appUser;

        public List<ClothingItem> ClothingItems { get; set; }

        public ListModel(RealDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }


        public void OnGet()
        {
            ClothingItems = dbContext.ClothingItems.ToList();
            var task = userManager.GetUserAsync(User);
            task.Wait();
            appUser = task.Result;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
