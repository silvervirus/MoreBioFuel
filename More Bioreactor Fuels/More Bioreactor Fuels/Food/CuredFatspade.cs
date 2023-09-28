using More_Bioreactor_Fuels.LockForever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.AdvencedFuel
{
    internal class bFCuredFatspade

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFCuredFatspade", "Cured Fatspade", "An excellent source of protein, B vitamins, iron and selenium, also high in cholesterol. ", Utilities.GetSprite(TechType.CuredSpadefish), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(bFSeaWater.Info.TechType);

            _ = prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {   new Ingredient(bFFatspade.Info.TechType, 1),
                    new Ingredient(TechType.Salt, 1),

                },
                

            })

                .WithFabricatorType(More_Bioreactor_Fuels.BioFuelFabricator.BioFuel)
                .WithStepsToFabricatorTab("BFF")
                .WithCraftingTime(0.5f);

            prefab.SetGameObject(new CloneTemplate(bFCuredFatspade.Info, TechType.FilteredWater)
            {
                ModifyPrefab = prefab1 =>
                {
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.foodValue = 50;
                    eatable.waterValue = -1;
                }
            });



            prefab.Register();
        }

    }
}
