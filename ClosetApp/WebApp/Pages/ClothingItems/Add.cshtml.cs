using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models.Domain;
using WebApp.Models.ViewModels;
using System.Drawing;
using Microsoft.Extensions.Hosting.Internal;

namespace WebApp.Pages.ClothingItems
{
    public class AddModel : PageModel
    {
        private readonly TestDbContext dbContext;


        public AddModel(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [BindProperty]
        public AddClothingItemViewModel AddClothingItemRequest { get; set; }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await AddClothingItemRequest.Image.CopyToAsync(memoryStream);
                //Convert viewmodel to domain model
                ClothingItem clothingItemDomainModel;
                if(AddClothingItemRequest.TopOrBottom == "Top") 
                {

                    clothingItemDomainModel = new TopBaseClothingItem
                    (
                        AddClothingItemRequest.Color,
                        AddClothingItemRequest.Material,
                        AddClothingItemRequest.TopDesign,
                        memoryStream.ToArray()
                    );
                }
                else
                {
                    clothingItemDomainModel = new BottomLayerClothingItem
                    (
                        AddClothingItemRequest.Color,
                        AddClothingItemRequest.Material,
                        AddClothingItemRequest.BottomDesign,
                        memoryStream.ToArray()
                    );
                }
                

                dbContext.TestClothingItems.Add(clothingItemDomainModel);
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
