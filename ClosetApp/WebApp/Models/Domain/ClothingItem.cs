namespace WebApp.Models.Domain
{
    public class ClothingItem
    {
        public Guid ClothingItemId { get; set; } 
        public Guid UserId { get; set; } 
        public ClothesColor Color { get; set; }
        public ClothesMaterial Material { get; set; }
        public Byte[] Image { get; set; }
        public List<Outfit> Outfits { get; set; } = new List<Outfit>();

        public ClothingItem() { }

        public ClothingItem(ClothesColor color, ClothesMaterial material, Byte[] image, Guid userId)
        {
            Color = color;
            Material = material;
            Image = image;
            UserId = userId;
        }
    }
}
