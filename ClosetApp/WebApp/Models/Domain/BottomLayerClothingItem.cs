namespace WebApp.Models.Domain
{
    public class BottomLayerClothingItem : ClothingItem
    {
        public BottomDesign Design { get; set; }

        public BottomLayerClothingItem(ClothesColor color, ClothesMaterial material, BottomDesign design, Byte[] image) : base(color, material, image)
        {
            Design = design;
        }
    }
}
