using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ClothingItem
    {
        public int ItemId { get; set; }
        public string ItemType { get; set; }
        public string ItemDesignColor { get; set; }
        //public Image?? ClothingPhoto {get; set;}
        public ClothingItem(int id, string type, string designColor)
        {
            ItemId = id;
            ItemType = type;
            ItemDesignColor = designColor;
        }
    }
}
