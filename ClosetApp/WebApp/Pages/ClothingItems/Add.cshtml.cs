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
    /// <summary>
    /// the add control where users can add clothing items to their closet.
    /// </summary>
    [Authorize]
    public class AddModel : PageModel
    {
        private readonly RealDbContext dbContext;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IWebHostEnvironment _environment;

        public ApplicationUser? appUser;
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="dbContext">the database</param>
        /// <param name="userManager">the user manager</param>
        /// <param name="environment">web environment</param>
        public AddModel(RealDbContext dbContext, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this._environment = environment;    
        }


        [BindProperty]
        public AddClothingItemViewModel AddClothingItemRequest { get; set; }
        /// <summary>
        /// the on get method, sets some things up
        /// </summary>
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
        /// <summary>
        /// uploads the current item to the database
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostUploadAsync()
        {
            if (AddClothingItemRequest.Image != null && AddClothingItemRequest.Image.Length > 0)
            {
                var fileName = Path.GetRandomFileName() + Path.GetExtension(AddClothingItemRequest.Image.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "images", "clothing", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await AddClothingItemRequest.Image.CopyToAsync(stream);
                }



                if (AddClothingItemRequest.TopDesign == TopDesign.none)
                {
                    AddClothingItemRequest.Type = ClothingType.Bottom;
                }
                if (AddClothingItemRequest.BottomDesign == BottomDesign.none)
                {
                    AddClothingItemRequest.Type = ClothingType.Top;
                }

                ClothingItem clothingItemDomainModel;
                if (AddClothingItemRequest.Type == ClothingType.Top)
                {

                    clothingItemDomainModel = new TopBaseClothingItem
                    (
                        AddClothingItemRequest.Color,
                        AddClothingItemRequest.Material,
                        AddClothingItemRequest.TopDesign,
                        Path.Combine("images", "clothing", fileName),
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
                        Path.Combine("images", "clothing", fileName),
                        AddClothingItemRequest.Id
                    );
                }
                dbContext.ClothingItems.Add(clothingItemDomainModel);
                await dbContext.SaveChangesAsync();

                ViewData["Message"] = "Clothing Item added Successfully!";
            }
            return Page();
        }
    }
}
