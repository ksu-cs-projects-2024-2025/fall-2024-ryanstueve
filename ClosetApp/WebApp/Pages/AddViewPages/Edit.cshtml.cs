using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models.ViewModels;

namespace WebApp.Pages.AddViewPages
{
    public class EditModel : PageModel
    {
        private readonly RealDbContext dbContext;
        [BindProperty]
        public EditClothingItemViewModel EditClothingItemViewModel { get; set; }

        public EditModel(RealDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void OnGet(Guid id)
        {
            var clothingItem = dbContext.ClothingItems.Find(id);

            if (clothingItem != null) {
                //Convert domain model to view model
                EditClothingItemViewModel = new EditClothingItemViewModel()
                {
                    Id = clothingItem.ClothingItemId,
                    Color = clothingItem.Color,
                    Material = clothingItem.Material,
                };
            }
        }

        public void OnPostUpdate()
        {

            if (EditClothingItemViewModel != null) {
                var existingClothingItem = dbContext.ClothingItems.Find(EditClothingItemViewModel.Id);
                if (existingClothingItem != null)
                {
                    //Convert ViewModel to DomainModel
                    existingClothingItem.Color = EditClothingItemViewModel.Color;
                    existingClothingItem.Material = EditClothingItemViewModel.Material;

                    dbContext.SaveChanges();

                    ViewData["Message"] = "Clothing Item Updated Successfully";

                }

            }
        }

        public IActionResult OnPostDelete()
        {
            var existingClothingItem = dbContext.ClothingItems.Find(EditClothingItemViewModel.Id);

            if (existingClothingItem != null)
            {
                dbContext.ClothingItems.Remove(existingClothingItem);
                dbContext.SaveChanges();

                return RedirectToPage("/ClothingItems/List");
            }
            return Page();
        }
    }
}
