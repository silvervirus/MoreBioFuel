using More_Bioreactor_Fuels.LockForever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.AdvencedFuel
{
    internal class bFDryDungCakes0

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFDryDungCakes0", "Dry Fertililzer Disk ", "Feces in order to be used as a fuel source 1 000 000ϟ. ", Utilities.GetSprite("bFDryDungCakes0"), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(bFSeaWater.Info.TechType);

            _ = prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 0,
                Ingredients = new List<Ingredient>
                {   new Ingredient(bFDungCake.Info.TechType, 3),
                    

                },
                LinkedItems = new List<TechType>
                {

                   bFDryDungCakes.Info.TechType,
                   


                }

            })

                .WithFabricatorType(More_Bioreactor_Fuels.BioFuelFabricator.BioFuel)
                .WithStepsToFabricatorTab("FBF")
                .WithCraftingTime(0.5f);



            prefab.SetGameObject(new CloneTemplate(bFDryDungCakes0.Info, TechType.CreepvinePiece)
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