using More_Bioreactor_Fuels.LockForever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.AdvencedFuel
{
    internal class bFSeaWaterFromPurpleTentacleSeed

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFSeaWaterFromPurpleTentacleSeed", "Sea Water ", "Water from the sea, compound of dissolved salts 1000ϟ ", Utilities.GetSprite("bFSeaWaterFromPurpleTentacleSeed"), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(bFSeaWater.Info.TechType);

            _ = prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {   new Ingredient(TechType.PurpleTentacleSeed, 10),
                    

                },
                LinkedItems = new List<TechType>
                {

                    bFSeaWater.Info.TechType,
                    bFSeaWater.Info.TechType,
                   


                }

            })

                .WithFabricatorType(More_Bioreactor_Fuels.BioFuelFabricator.BioFuel)
                .WithStepsToFabricatorTab("BLD")
                .WithCraftingTime(0.5f);


            prefab.SetGameObject(new CloneTemplate(bFSeaWaterFromPurpleTentacleSeed.Info, TechType.DisinfectedWater)
            {
                ModifyPrefab = prefab1 =>
                {
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.foodValue = 10;
                    eatable.waterValue = -10;
                }
            });



            prefab.Register();
        }

    }
}