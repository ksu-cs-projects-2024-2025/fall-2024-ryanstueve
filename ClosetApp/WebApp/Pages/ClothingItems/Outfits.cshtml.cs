using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models.Domain;
using WebApp.Models;

namespace WebApp.Pages.ClothingItems
{
    public class OutfitsModel : PageModel
    {

        private readonly RealDbContext dbContext;

        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUser? appUser;

        public List<Outfit> Outfits { get; set; }

        public OutfitsModel(RealDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public void OnGet()
        {
            Outfits = dbContext.Outfits.ToList();
            var task = userManager.GetUserAsync(User);
            task.Wait();
            appUser = task.Result;
        }
    }
}
