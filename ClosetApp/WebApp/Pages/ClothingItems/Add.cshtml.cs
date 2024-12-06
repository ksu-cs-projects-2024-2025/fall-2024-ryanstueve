using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models.Domain;
using WebApp.Models.ViewModels;
using System.Drawing;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using WebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages.ClothingItems
{
    [Authorize]
    public class AddModel : PageModel
    {
        private readonly RealDbContext dbContext;

        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUser? appUser;

        public AddModel(RealDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }


        [BindProperty]
        public AddClothingItemViewModel AddClothingItemRequest { get; set; }
        public void OnGet()
        {
            var task = userManager.GetUserAsync(User);
            task.Wait();
            appUser = task.Result;
            AddClothingItemRequest = new AddClothingItemViewModel()
            {
                Id = appUser.UserId
            };
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await AddClothingItemRequest.Image.CopyToAsync(memoryStream);
                if(AddClothingItemRequest.TopDesign == TopDesign.none)
                {
                    AddClothingItemRequest.Type = ClothingType.Bottom;
                }
                if (AddClothingItemRequest.BottomDesign == BottomDesign.none)
                {
                    AddClothingItemRequest.Type = ClothingType.Top;
                }
                //Convert viewmodel to domain model
                ClothingItem clothingItemDomainModel;
                if(AddClothingItemRequest.Type == ClothingType.Top) 
                {

                    clothingItemDomainModel = new TopBaseClothingItem
                    (
                        AddClothingItemRequest.Color,
                        AddClothingItemRequest.Material,
                        AddClothingItemRequest.TopDesign,
                        memoryStream.ToArray(),
                        AddClothingItemRequest.Id
                    );
                }
                else
                {
                    clothingItemDomainModel = new BottomLayerClothingItem
                    (
                        AddClothingItemRequest.Color,
                        AddClothingItemRequest.Material,
                        AddClothingItemRequest.BottomDesign,
                        memoryStream.ToArray(),
                        AddClothingItemRequest.Id
                    );
                }
                dbContext.ClothingItems.Add(clothingItemDomainModel);
                await dbContext.SaveChangesAsync();

                ViewData["Message"] = "Clothing Item added Successfully!";
            }
            return Page();
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
