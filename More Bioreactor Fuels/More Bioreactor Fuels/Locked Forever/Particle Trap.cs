using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.LockForever
{
    internal class bFParticleTrap

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFParticleTrap", "Particle Trap ", "Device for the storage of charged particles using strong magnetic and electric fileds. ", Utilities.GetSprite("bFParticleTrap"), 1, 1);
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

               

            prefab.SetGameObject(new CloneTemplate(bFParticleTrap.Info, TechType.ReactorRod)
            {
                ModifyPrefab = prefab1 =>
                {
                   
                }
            });



            prefab.Register();
        }

    }
}