using Microsoft.Identity.Client;
using System.Drawing;
using WebApp.Models.Domain;

namespace WebApp.Models.ViewModels
{
    /// <summary>
    /// a view model representation of a clothing item that allows for adding clothingitems
    /// </summary>
    public class AddClothingItemViewModel
    {
        public ClothesColor Color { get; set; }
        public ClothesMaterial Material { get; set; }
        public ClothingType Type { get; set;}
        public TopDesign TopDesign { get; set; }
        public BottomDesign BottomDesign { get; set; }
        public Guid Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
