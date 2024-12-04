using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models.Domain
{
    public class Outfit
    {
        public Guid OutfitId { get; set; }
        public Guid UserId { get; set; }

        public List<ClothingItem> OutfitClothes { get; set; } = new List<ClothingItem>();
        public Outfit(List<ClothingItem> outfitClothes) 
        {
            OutfitClothes = outfitClothes;
        }
    }
}
