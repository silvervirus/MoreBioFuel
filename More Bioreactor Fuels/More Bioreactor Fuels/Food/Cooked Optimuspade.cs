using More_Bioreactor_Fuels.LockForever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.AdvencedFuel
{
    internal class bFCookedOptimuspade

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFCookedOptimuspade", "Cooked Optimuspade", "Eating tasty fish makes times spent in the outdoors all the more enjoyable. ", Utilities.GetSprite(TechType.CookedSpadefish), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(bFSeaWater.Info.TechType);

            _ = prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {   new Ingredient(bFOptimuspade.Info.TechType, 1),
                    

                },
                

            })

                .WithFabricatorType(More_Bioreactor_Fuels.BioFuelFabricator.BioFuel)
                .WithStepsToFabricatorTab("BFF")
                .WithCraftingTime(0.5f);

            prefab.SetGameObject(new CloneTemplate(bFCookedOptimuspade.Info, TechType.FilteredWater)
            {
                ModifyPrefab = prefab1 =>
                {
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.foodValue = 55;
                    eatable.waterValue = 11;
                }
            });



            prefab.Register();
        }

    }
}
