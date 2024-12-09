namespace WebApp.Models.Domain
{
    /// <summary>
    /// base class for lcothing items
    /// </summary>
    public class ClothingItem
    {
        public Guid ClothingItemId { get; set; } 
        public Guid UserId { get; set; } 
        public ClothesColor Color { get; set; }
        public ClothesMaterial Material { get; set; }
        public string ImagePath { get; set; }
        public List<Outfit> Outfits { get; set; } = new List<Outfit>();

        public ClothingItem() { }

        public ClothingItem(ClothesColor color, ClothesMaterial material, string imagePath, Guid userId)
        {
            Color = color;
            Material = material;
            ImagePath = imagePath;
            UserId = userId;
        }
    }
}
