using More_Bioreactor_Fuels.LockForever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.AdvencedFuel
{
    internal class bFCookedFatspade

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFCookedFatspade", "Cooked Fatspade", "One of the most nutritious foods you can eat. It also happen to be high in cholesterol. ", Utilities.GetSprite(TechType.CookedSpadefish), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(bFSeaWater.Info.TechType);

            _ = prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {   new Ingredient(bFFatspade.Info.TechType, 1),
                    

                },
                

            })

                .WithFabricatorType(More_Bioreactor_Fuels.BioFuelFabricator.BioFuel)
                .WithStepsToFabricatorTab("BFF")
                .WithCraftingTime(0.5f);

            prefab.SetGameObject(new CloneTemplate(bFCookedFatspade.Info, TechType.FilteredWater)
            {
                ModifyPrefab = prefab1 =>
                {
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.foodValue = 50;
                    eatable.waterValue = 5;
                }
            });



            prefab.Register();
        }

    }
}
