using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.LockForever
{
    internal class bFDryDung

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFDryDung", "Dry Animal Scat ", "Dehydrated alien feces 7 000ϟ. ", Utilities.GetSprite("bFDryDung"), 1, 1);
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

               

            prefab.SetGameObject(new CloneTemplate(bFDryDung.Info, TechType.FilteredWater)
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