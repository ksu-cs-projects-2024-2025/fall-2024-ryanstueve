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
    /// <summary>
    /// a list control that allows for users to see all their clothing items and choose to edit them
    /// </summary>
    [Authorize]
    public class ListModel : PageModel
    {
        private readonly RealDbContext dbContext;

        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUser? appUser;

        public List<ClothingItem> ClothingItems { get; set; }
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="dbContext">the database</param>
        /// <param name="userManager">the user manager</param>
        public ListModel(RealDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        /// <summary>
        /// on get method sets up a few things
        /// </summary>
        public void OnGet()
        {
            ClothingItems = dbContext.ClothingItems.ToList();
            var task = userManager.GetUserAsync(User);
            task.Wait();
            appUser = task.Result;
        }
    }
}
