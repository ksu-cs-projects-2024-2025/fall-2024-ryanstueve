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
    /// <summary>
    /// an Outfit control that allows people to see their outfits and generate ones too
    /// </summary>
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
        /// <summary>
        /// the constructor
        /// </summary>
        /// <param name="dbContext">databse</param>
        /// <param name="userManager">user manager</param>
        public OutfitsModel(RealDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        /// <summary>
        /// on get doesn't do anything here
        /// </summary>
        public void OnGet()
        {
            
        }
        /// <summary>
        /// deletes outfit
        /// </summary>
        /// <param name="id">outfit getting deleted</param>
        /// <returns></returns>
        public IActionResult OnPostDelete(Guid id)
        {

            var outfit = dbContext.Outfits.Find(id);
            if (outfit != null)
            {
                dbContext.Outfits.Remove(outfit);
                dbContext.SaveChanges();
            }


            return RedirectToAction("Index");
        }
        /// <summary>
        /// generates new outfits based on rules engine
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostGenerate()
        {
            var repository = new RuleRepository();
            //repository.Load(x => x.From(typeof(TopBottomOutfitRule).Assembly));

            repository.Load(x => x.From(Assembly.GetExecutingAssembly()));


            var factory = repository.Compile();


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
                bool ogOutfit = true;
                foreach (var sndOutfit in dbContext.Outfits.Include(o => o.OutfitClothes).ToList()) {

                    if (outfit.OutfitClothes.Contains(sndOutfit.OutfitClothes[0]) && outfit.OutfitClothes.Contains(sndOutfit.OutfitClothes[1]))
                    {
                        ogOutfit = false;
                        break;
                    }
                }
                if(ogOutfit)
                {
                    dbContext.Outfits.Add(outfit);
                }
            }
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
