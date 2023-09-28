using More_Bioreactor_Fuels.LockForever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.AdvencedFuel
{
    internal class bFDungCake0

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFDungCake0", "Dung Disk ", "Solid remains of food that could not be digested 100 000ϟ. ", Utilities.GetSprite("bFDungCakes"), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(bFSeaWater.Info.TechType);

            _ = prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {   new Ingredient(bFDryDung.Info.TechType, 10),
                     new Ingredient(bFSeaWater.Info.TechType, 5),

                },
                LinkedItems = new List<TechType>
                {

                   bFDungCake.Info.TechType,



                }

            })

                .WithFabricatorType(More_Bioreactor_Fuels.BioFuelFabricator.BioFuel)
                .WithStepsToFabricatorTab("FBF")
                .WithCraftingTime(0.5f);




            prefab.SetGameObject(new CloneTemplate(bFDryDungCakes.Info, TechType.CreepvinePiece)
            {
                ModifyPrefab = prefab1 =>
                {
                   
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.foodValue = -50;
                    eatable.waterValue = -50;
                }
            });



            prefab.Register();
        }

    }
}