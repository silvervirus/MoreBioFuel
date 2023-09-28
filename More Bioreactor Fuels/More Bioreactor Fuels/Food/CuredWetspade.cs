using More_Bioreactor_Fuels.LockForever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.AdvencedFuel
{
    internal class bFCuredWetspade

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFCuredWetspade", "Cured Wetspade", "Healty, good source of vitamins A and D. ", Utilities.GetSprite(TechType.CuredSpadefish), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(bFSeaWater.Info.TechType);

            _ = prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {   new Ingredient(bFWetspade.Info.TechType, 1),
                    new Ingredient(TechType.Salt, 1),

                },
                

            })

                .WithFabricatorType(More_Bioreactor_Fuels.BioFuelFabricator.BioFuel)
                .WithStepsToFabricatorTab("BFF")
                .WithCraftingTime(0.5f);

            prefab.SetGameObject(new CloneTemplate(bFCuredWetspade.Info, TechType.FilteredWater)
            {
                ModifyPrefab = prefab1 =>
                {
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.foodValue = 10;
                    eatable.waterValue = 30;
                }
            });



            prefab.Register();
        }

    }
}
