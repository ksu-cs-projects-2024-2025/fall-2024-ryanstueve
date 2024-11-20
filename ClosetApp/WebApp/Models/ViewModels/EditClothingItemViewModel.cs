using WebApp.Models.Domain;

namespace WebApp.Models.ViewModels
{
    public class EditClothingItemViewModel
    {
        public Guid Id { get; set; }

        public ClothesColor Color { get; set; }

        public ClothesMaterial Material { get; set; }
    }
}
