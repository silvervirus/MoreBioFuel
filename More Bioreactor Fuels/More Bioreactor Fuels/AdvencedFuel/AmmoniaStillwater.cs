using More_Bioreactor_Fuels.LockForever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.AdvencedFuel
{
    internal class AmmoniaStillwater

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFAmmoniaFromStillWater", "Ammonia", "Ammonia is used as a refrigerant gas, for purification of water supplies, and in the manufacture of plastics, explosives, textiles, pesticides, dyes and other chemicals 11 000 ", Utilities.GetSprite("bFAmmoniaFromStillWater"), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(bFSeaWater.Info.TechType);

            _ = prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {   new Ingredient(bFSeaWater.Info.TechType, 10),
                    new Ingredient(TechType.HydrochloricAcid, 2),

                },
                LinkedItems = new List<TechType>
                {

                   bFAmmonia.Info.TechType,
                    



                }

            })

                .WithFabricatorType(More_Bioreactor_Fuels.BioFuelFabricator.BioFuel)
                .WithStepsToFabricatorTab("BAF")
                .WithCraftingTime(0.5f);

            prefab.SetGameObject(new CloneTemplate(AmmoniaStillwater.Info, TechType.FilteredWater)
            {
                ModifyPrefab = prefab1 =>
                {
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.foodValue = 48;
                    eatable.waterValue = 38;
                }
            });



            prefab.Register();
        }

    }
}
