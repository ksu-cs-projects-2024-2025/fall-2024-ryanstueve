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

        private ApplicationUser? _appUser;

        public ApplicationUser? appUser
        {
            get
            {
                var task = userManager.GetUserAsync(User);
                task.Wait();
                _appUser = task.Result;
                return _appUser;
            }
        }

        public List<ClothingItem> ClothingItems {
            get
            {
                return dbContext.ClothingItems.ToList();
            } 
        }

        private List<BottomLayerClothingItem> _bottomItems;

        public List<BottomLayerClothingItem> BottomItems {
            get
            {
                _bottomItems = new List<BottomLayerClothingItem>();
                foreach (var item in ClothingItems)
                {
                    if (item.UserId == appUser.UserId || item.UserId == new Guid("ba3adfea-ef93-4639-85bc-e59d0f794571"))
                    {
                        if (item is BottomLayerClothingItem)
                        {
                            _bottomItems.Add((BottomLayerClothingItem)item);
                        }
                    }
                }
                return _bottomItems;
            }}

        private List<TopBaseClothingItem> _topItems;
        public List<TopBaseClothingItem> TopItems
        {
            get
            {
                _topItems = new List<TopBaseClothingItem>();
                foreach (var item in ClothingItems)
                {
                    if (item.UserId == appUser.UserId || item.UserId == new Guid("ba3adfea-ef93-4639-85bc-e59d0f794571"))
                    {
                        if (item is TopBaseClothingItem)
                        {
                            _topItems.Add((TopBaseClothingItem)item);
                        }
                    }
                }
                return _topItems;
            }
        }

        public int SlideIndex { get; set; } = 1;
        public int SlideIndex1 { get; set; } = 1;


        public IndexModel(RealDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public void OnGet()
        {
            HttpContext.Session.SetInt32("SlideIndex", SlideIndex);
            HttpContext.Session.SetInt32("SlideIndex1", SlideIndex1);
        }

        public IActionResult OnPostCSharpFunction1()
        {
            SlideIndex = HttpContext.Session.GetInt32("SlideIndex") ?? 0;

            SlideIndex--;
            if (SlideIndex > TopItems.Count)
            {
                SlideIndex = 1;
            }
            if (SlideIndex < 1)
            {
                SlideIndex = TopItems.Count;
            }
            HttpContext.Session.SetInt32("SlideIndex", SlideIndex);

            return new EmptyResult();
        }
        public IActionResult OnPostCSharpFunction2()
        {
            SlideIndex = HttpContext.Session.GetInt32("SlideIndex") ?? 0;
            SlideIndex++;
            if (SlideIndex > TopItems.Count)
            {
                SlideIndex = 1;
            }
            if (SlideIndex < 1)
            {
                SlideIndex = TopItems.Count;
            }
            HttpContext.Session.SetInt32("SlideIndex", SlideIndex);

            return new EmptyResult();
        }
        public IActionResult OnPostCSharpFunction3()
        {

            SlideIndex1 = HttpContext.Session.GetInt32("SlideIndex1") ?? 0;
            SlideIndex1--;
            if (SlideIndex1 > BottomItems.Count)
            {
                SlideIndex1 = 1;
            }
            if (SlideIndex1 < 1)
            {
                SlideIndex1 = BottomItems.Count;
            }
            HttpContext.Session.SetInt32("SlideIndex1", SlideIndex1);

            return new EmptyResult();
        }

        public IActionResult OnPostCSharpFunction4()
        {
            SlideIndex1 = HttpContext.Session.GetInt32("SlideIndex1") ?? 0;
            SlideIndex1++;
            if (SlideIndex1 > BottomItems.Count) 
            {
                SlideIndex1 = 1;
            }
            if (SlideIndex1 < 1) 
            {
                SlideIndex1 = BottomItems.Count;
            }
            HttpContext.Session.SetInt32("SlideIndex1", SlideIndex1);

            return new EmptyResult();
        }

        public async Task<IActionResult> OnPostMakeOutfit()
        {
            Console.WriteLine("in the method");
            SlideIndex = HttpContext.Session.GetInt32("SlideIndex") ?? 0;
            SlideIndex1 = HttpContext.Session.GetInt32("SlideIndex1") ?? 0;
            Outfit outfit = new Outfit();
            outfit.OutfitClothes = new List<ClothingItem>
            {
                TopItems[SlideIndex-1], BottomItems[SlideIndex1-1]
            };
            outfit.UserId = appUser.UserId;
            dbContext.Outfits.Add(outfit);
            await dbContext.SaveChangesAsync();
            return Content("Outfit Created");
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
