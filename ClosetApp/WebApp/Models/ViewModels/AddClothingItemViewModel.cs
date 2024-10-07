using System.Drawing;

namespace WebApp.Models.ViewModels
{
    public class AddClothingItemViewModel
    {
        public string Color { get; set; }
        public string Type { get; set; }

        public IFormFile Image { get; set; }
    }
}
