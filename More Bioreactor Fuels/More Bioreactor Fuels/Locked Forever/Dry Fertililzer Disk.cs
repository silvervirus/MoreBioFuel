using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.LockForever
{
    internal class bFDryDungCakes

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFDryDungCakes", "Dry Animal Scat ", "Feces in order to be used as a fuel source 1 000 000ϟ ", Utilities.GetSprite("bFDryDungCakes"), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(bFSeaWater.Info.TechType);

            _ = prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {   new Ingredient(TechType.WaterFiltrationSuitWater, 2),
                    new Ingredient(TechType.HydrochloricAcid, 2),

                },
               

            });

               

            prefab.SetGameObject(new CloneTemplate(bFDryDungCakes.Info, TechType.FilteredWater)
            {
                ModifyPrefab = prefab1 =>
                {
                    prefab1.EnsureComponent<Pickupable>();
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.foodValue = 0;
                    eatable.waterValue = -50;
                }
            });



            prefab.Register();
        }

    }
}