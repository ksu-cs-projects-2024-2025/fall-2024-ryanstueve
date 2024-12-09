using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models.ViewModels;

namespace WebApp.Pages.ClothingItems
{
    /// <summary>
    /// an edit control that allows for users to edit their clothing items
    /// </summary>
    public class EditModel : PageModel
    {
        private readonly RealDbContext dbContext;
        [BindProperty]
        public EditClothingItemViewModel EditClothingItemViewModel { get; set; }
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="dbContext">the database</param>
        public EditModel(RealDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// the on get method sets up a few things
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(Guid id)
        {
            var clothingItem = dbContext.ClothingItems.Find(id);

            if (clothingItem != null) {

                EditClothingItemViewModel = new EditClothingItemViewModel()
                {
                    Id = clothingItem.ClothingItemId,
                    Color = clothingItem.Color,
                    Material = clothingItem.Material,
                };
            }
        }
        /// <summary>
        /// updates the clothing item and sends those changes to the database
        /// </summary>
        public void OnPostUpdate()
        {

            if (EditClothingItemViewModel != null) {
                var existingClothingItem = dbContext.ClothingItems.Find(EditClothingItemViewModel.Id);
                if (existingClothingItem != null)
                {

                    existingClothingItem.Color = EditClothingItemViewModel.Color;
                    existingClothingItem.Material = EditClothingItemViewModel.Material;

                    dbContext.SaveChanges();

                    ViewData["Message"] = "Clothing Item Updated Successfully";

                }

            }
        }
        /// <summary>
        /// deletes an item and updates the database
        /// </summary>
        /// <returns></returns>
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
