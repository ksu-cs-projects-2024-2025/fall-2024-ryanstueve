using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Models.Domain;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.ViewModels;
using NRules;
using NRules.Fluent;
using System.Drawing;
using System.Reflection;


namespace WebApp.Pages.ClothingItems
{
    public class OutfitsModel : PageModel
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

        private List<Outfit> _outfits;

        public List<Outfit> Outfits
        {
            get
            {
                return _outfits = dbContext.Outfits.Include(o => o.OutfitClothes).ToList();
            }
        }

        public OutfitsModel(RealDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public void OnGet()
        {
            
        }
        public IActionResult OnPostDelete(Guid id)
        {
            // Find the outfit to delete
            var outfit = dbContext.Outfits.Find(id);
            if (outfit != null)
            {
                dbContext.Outfits.Remove(outfit);
                dbContext.SaveChanges();
            }

            // Redirect back to the index page after deletion
            return RedirectToAction("Index");
        }

        public IActionResult OnPostGenerate()
        {
            var repository = new RuleRepository();
            //repository.Load(x => x.From(typeof(TopBottomOutfitRule).Assembly));

            repository.Load(x => x.From(Assembly.GetExecutingAssembly()));

            //Compile rules
            var factory = repository.Compile();

            //Create a working session
            var session = factory.CreateSession();

            List<Outfit> outfits;

            foreach(var item in dbContext.ClothingItems.ToList())
            {
                if (item.UserId == appUser.UserId)
                {
                    session.Insert(item);
                }
            }

            session.Fire();

            outfits = session.Query<Outfit>().ToList();
            foreach(var outfit in outfits)
            {
                dbContext.Outfits.Add(outfit);
            }
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
