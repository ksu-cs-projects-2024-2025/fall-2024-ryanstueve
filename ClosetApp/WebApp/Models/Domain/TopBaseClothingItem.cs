namespace WebApp.Models.Domain
{
    public class TopBaseClothingItem : ClothingItem
    {
        public TopDesign Design { get; set; }

        public TopBaseClothingItem(ClothesColor color, ClothesMaterial material, TopDesign design, Byte[] image, Guid userId) : base(color, material, image, userId)
        {
            Design = design;
        }
    }
}
