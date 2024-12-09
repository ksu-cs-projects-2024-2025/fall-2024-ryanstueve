using NRules.Fluent.Dsl;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Domain;

namespace WebApp.Models.RulesEngine
{
    /// <summary>
    /// a rule for the rules engine that creats athletic clothes
    /// </summary>
    public class AthleticOutfitRule : Rule
    {
        /// <summary>
        /// defines the rule
        /// </summary>
        public override void Define()
        {
            ClothingItem topItem = default;
            ClothingItem bottomItem = default;


            When()
                .Match<ClothingItem>(() => topItem, c => c is TopBaseClothingItem, c => AthleticTop(c))
                .Match<ClothingItem>(() => bottomItem, b => b is BottomLayerClothingItem, b => AthleticBottom(b));



            Then()
               .Do(ctx => ctx.Insert(AddItemToOutfit(topItem, bottomItem)))
               .Do(ctx => Console.WriteLine("matched outfit"))
               .Do(ctx => System.Diagnostics.Debug.WriteLine("matched outfit"));
        }
        /// <summary>
        /// adds item to outfit
        /// </summary>
        /// <param name="topItem">top item</param>
        /// <param name="bottomItem">bottom item</param>
        /// <returns></returns>
        public static Outfit AddItemToOutfit(ClothingItem topItem, ClothingItem bottomItem)
        {
            Outfit outfit = new Outfit(new List<ClothingItem> { topItem, bottomItem }, topItem.UserId);
            return outfit;
        }
        /// <summary>
        /// filters to an athletic top
        /// </summary>
        /// <param name="item">the item in question</param>
        /// <returns></returns>
        public static bool AthleticTop(ClothingItem item)
        {
            if (item is TopBaseClothingItem)
            {
                TopBaseClothingItem item2 = (TopBaseClothingItem)item;
                if (item2.Material == ClothesMaterial.cotton || item2.Material == ClothesMaterial.polyester || item2.Material == ClothesMaterial.nylon || item2.Material == ClothesMaterial.spandex)
                {
                    if(item2.Design == TopDesign.shortSleeve || item2.Design == TopDesign.longSleeve || item2.Design == TopDesign.hoodie) 
                    { 
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// filters to an athletic bottom item
        /// </summary>
        /// <param name="item">item in question</param>
        /// <returns></returns>
        public static bool AthleticBottom(ClothingItem item)
        {
            if (item is BottomLayerClothingItem)
            {
                BottomLayerClothingItem item2 = (BottomLayerClothingItem)item;
                if (item2.Material == ClothesMaterial.polyester || item2.Material == ClothesMaterial.nylon || item2.Material == ClothesMaterial.spandex)
                {
                    if (item2.Design == BottomDesign.sweatPants || item2.Design == BottomDesign.shorts)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

    }
}
