using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.LockForever
{
    internal class bFAnammoxBacteria

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFAnammoxBacteria", "Anammox Bacteria ", "Known for their ability to convert ammonium into nitrogen gas without using oxygen. ", Utilities.GetSprite("bFAnammoxBacteria"), 1, 1);
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

               

            prefab.SetGameObject(new CloneTemplate(bFAnammoxBacteria.Info, TechType.Bleach)
            {
                ModifyPrefab = prefab1 =>
                {
                   
                }
            });



            prefab.Register();
        }

    }
}