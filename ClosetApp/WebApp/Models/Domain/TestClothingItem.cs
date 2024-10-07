using System.Drawing;

namespace WebApp.Models.Domain
{
    public class TestClothingItem
    {

        public Guid Id { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }

        public Byte[] Image { get; set; }
    }
}
