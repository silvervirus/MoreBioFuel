using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.LockForever
{
    internal class bFBloodspadefishEgg

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFBloodspadefishEgg", "Bloodspade Egg ", "Triglyceride environment form organism vulnerable to mutations. Further research is needed 12 000ϟ.", Utilities.GetSprite("bFBloodspadefishEgg"), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(bFSeaWater.Info.TechType);

            _ = prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 2,
                Ingredients = new List<Ingredient>
                {   new Ingredient(TechType.WaterFiltrationSuitWater, 2),
                    new Ingredient(TechType.HydrochloricAcid, 2),

                },
               

            });

               

            prefab.SetGameObject(new CloneTemplate(bFBloodspadefishEgg.Info, TechType.Spadefish)
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