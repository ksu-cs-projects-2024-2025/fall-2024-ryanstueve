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
    /// a rule for the rules engine that creates nice outfits
    /// </summary>
    public class NiceOutfitRule : Rule
    {
        /// <summary>
        /// defines the rule
        /// </summary>
        public override void Define()
        {
            ClothingItem topItem = default;
            ClothingItem bottomItem = default;


            When()
                .Match<ClothingItem>(() => topItem, c => c is TopBaseClothingItem, c => NiceTop(c))
                .Match<ClothingItem>(() => bottomItem, b => b is BottomLayerClothingItem, b => NiceBottom(b));



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
        /// filters to a "nice" top
        /// </summary>
        /// <param name="item">the item in question</param>
        /// <returns></returns>
        public static bool NiceTop(ClothingItem item)
        {
            if (item is TopBaseClothingItem)
            {
                TopBaseClothingItem item2 = (TopBaseClothingItem)item;
                if (item2.Design == TopDesign.dressShirt || item2.Design == TopDesign.poloShirt || item2.Design == TopDesign.sweater)
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
        /// <summary>
        /// filters to a "nice" bottom
        /// </summary>
        /// <param name="item">the item in question</param>
        /// <returns></returns>
        public static bool NiceBottom(ClothingItem item)
        {
            if (item is BottomLayerClothingItem)
            {
                BottomLayerClothingItem item2 = (BottomLayerClothingItem)item;
                if (item2.Design == BottomDesign.dressPants || item2.Design == BottomDesign.pants)
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

    }


}
