namespace WebApp.Models.Domain
{
    /// <summary>
    /// representation of top clothing items, inheriting from the base clothing item
    /// </summary>
    public class TopBaseClothingItem : ClothingItem
    {
        public TopDesign Design { get; set; }

        public TopBaseClothingItem() { }

        public TopBaseClothingItem(ClothesColor color, ClothesMaterial material, TopDesign design, string image, Guid userId) : base(color, material, image, userId)
        {
            Design = design;
        }

        public TopBaseClothingItem(ClothesColor color, ClothesMaterial material, TopDesign design, string image, Guid userId, Guid id) : base(color, material, image, userId, id)
        {
            Design = design;
        }
    }
}
