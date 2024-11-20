namespace WebApp.Models.Domain
{
    public class ClothingItem
    {
        public ClothesColor Color { get; set; }
        public ClothesMaterial Material { get; set; }
        public Byte[] Image { get; set; }
        public Guid Id { get; set; }

        public ClothingItem(ClothesColor color, ClothesMaterial material, Byte[] image)
        {
            Color = color;
            Material = material;
            Image = image;
        }
    }
}
