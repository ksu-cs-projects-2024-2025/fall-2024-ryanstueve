using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Text.Json;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.Domain;

namespace WebApp.Pages
{
    [Authorize]
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {

        private readonly RealDbContext dbContext;

        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUser? appUser;

        public List<ClothingItem> ClothingItems { get; set; }

        public int SlideIndex { get; set; } = 0;
        public int SlideIndex1 { get; set; }


        public IndexModel(RealDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public void OnGet()
        {
            var task = userManager.GetUserAsync(User);
            task.Wait();
            appUser = task.Result;
            ClothingItems = dbContext.ClothingItems.ToList();
        }

        public IActionResult OnPostCSharpFunction()
        {
            if (Request.Form["callCSharp"] == "true")
            {
                SlideIndex = 3;
            }
            return Content("C# function executed");
        }

        //create a button to save an outfit. You would write a function that gets the current n values of
        //both the top and the bottom outfits. you would then create two lists that include all of the
        //top outfits and all of the bottom outfits. then you would use the two numbers to get the outfits
        //you would then add those to the outfits table.

        /*
        public class ReceiveDataModel
        {
            public int Number { get; set; }
        }

        public IActionResult OnPostReceiveData([FromBody] ReceiveDataModel data)
        {
            var number = data?.Number;
            return new JsonResult(new { status = "success", receivedData = number });
        }*/
    }
}
