﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.LockForever
{
    internal class bFCOPlantOil

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFCOPlantOil", "Bottle Of Plant Oil ", "Fats taken from plants 3 000ϟ. ", Utilities.GetSprite("bFCOPlantOil"), 1, 1);
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

               

            prefab.SetGameObject(new CloneTemplate(bFCOPlantOil.Info, TechType.FilteredWater)
            {
                ModifyPrefab = prefab1 =>
                {
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.foodValue = 60;
                    eatable.waterValue = -15;
                }
            });



            prefab.Register();
        }

    }
}