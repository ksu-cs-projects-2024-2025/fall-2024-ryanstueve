using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models.ViewModels;

namespace WebApp.Pages.ClothingItems
{
    public class EditModel : PageModel
    {
        private readonly TestDbContext dbContext;
        [BindProperty]
        public EditClothingItemViewModel EditClothingItemViewModel { get; set; }

        public EditModel(TestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void OnGet(Guid id)
        {
            var clothingItem = dbContext.TestClothingItems.Find(id);

            if (clothingItem != null) {
                //Convert domain model to view model
                EditClothingItemViewModel = new EditClothingItemViewModel()
                {
                    Id = clothingItem.Id,
                    Color = clothingItem.Color,
                    Type = clothingItem.Type,
                };
            }
        }

        public void OnPostUpdate()
        {

            if (EditClothingItemViewModel != null) {
                var existingClothingItem = dbContext.TestClothingItems.Find(EditClothingItemViewModel.Id);
                if (existingClothingItem != null)
                {
                    //Convert ViewModel to DomainModel
                    existingClothingItem.Color = EditClothingItemViewModel.Color;
                    existingClothingItem.Type = EditClothingItemViewModel.Type;

                    dbContext.SaveChanges();

                    ViewData["Message"] = "Clothing Item Updated Successfully";

                }

            }
        }

        public IActionResult OnPostDelete()
        {
            var existingClothingItem = dbContext.TestClothingItems.Find(EditClothingItemViewModel.Id);

            if (existingClothingItem != null)
            {
                dbContext.TestClothingItems.Remove(existingClothingItem);
                dbContext.SaveChanges();

                return RedirectToPage("/ClothingItems/List");
            }
            return Page();
        }
    }
}
