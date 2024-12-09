namespace WebApp.Models.Domain
{
    /// <summary>
    /// a representation of bottom clothing items inheriting the base clothing item
    /// </summary>
    public class BottomLayerClothingItem : ClothingItem
    {
        public BottomDesign Design { get; set; }

        public BottomLayerClothingItem() { }

        public BottomLayerClothingItem(ClothesColor color, ClothesMaterial material, BottomDesign design, string image, Guid userId) : base(color, material, image, userId)
        {
            Design = design;
        }
    }
}
