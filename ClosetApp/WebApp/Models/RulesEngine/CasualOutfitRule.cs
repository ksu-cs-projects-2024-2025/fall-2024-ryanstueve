using Microsoft.CodeAnalysis.CSharp.Syntax;
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
    public class CasualOutfitRule : Rule
    {
        public override void Define()
        {
            ClothingItem topItem = default;
            ClothingItem bottomItem = default;


            When()
                .Match<ClothingItem>(() => topItem, c => c is TopBaseClothingItem, c => CasualTop(c))
                .Match<ClothingItem>(() => bottomItem, b => b is BottomLayerClothingItem, b => CasualBottom(b));



            Then()
               .Do(ctx => ctx.Insert(AddItemToOutfit(topItem, bottomItem)))
               .Do(ctx => Console.WriteLine("matched outfit"))
               .Do(ctx => System.Diagnostics.Debug.WriteLine("matched outfit"));
        }

        public static Outfit AddItemToOutfit(ClothingItem topItem, ClothingItem bottomItem)
        {
            Outfit outfit = new Outfit(new List<ClothingItem> { topItem, bottomItem }, topItem.UserId);
            return outfit;
        }

        public static bool CasualTop(ClothingItem item)
        {
            if (item is TopBaseClothingItem)
            {
                TopBaseClothingItem item2 = (TopBaseClothingItem)item;
                if (item2.Material == ClothesMaterial.cotton || item2.Material == ClothesMaterial.polyester || item2.Material == ClothesMaterial.wool)
                {
                    if (item2.Design == TopDesign.shortSleeve || item2.Design == TopDesign.longSleeve || item2.Design == TopDesign.hoodie || item2.Design == TopDesign.crewneck || item2.Design == TopDesign.flannelShirt)
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

        public static bool CasualBottom(ClothingItem item)
        {
            if (item is BottomLayerClothingItem)
            {
                BottomLayerClothingItem item2 = (BottomLayerClothingItem)item;
                if (item2.Design == BottomDesign.shorts)
                {
                    if (item2.Material == ClothesMaterial.khaki)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (item2.Design == BottomDesign.jeans)
                {
                    return true;
                }
                else if (item2.Design == BottomDesign.pants)
                {
                    if (item2.Material == ClothesMaterial.khaki)
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
