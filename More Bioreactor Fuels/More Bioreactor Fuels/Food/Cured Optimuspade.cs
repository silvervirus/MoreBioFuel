using More_Bioreactor_Fuels.LockForever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.AdvencedFuel
{
    internal class bFCuredOptimuspade

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFCuredOptimuspade", "Cured Optimuspade", "Delicious, hearty meal is an important part of all our trips. ", Utilities.GetSprite(TechType.CuredSpadefish), 1, 1);
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
                    eatable.waterValue = 4;
                }
            });



            prefab.Register();
        }

    }
}
