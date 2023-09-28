using More_Bioreactor_Fuels.LockForever;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Bioreactor_Fuels.AdvencedFuel
{
    internal class bFDungCakePile

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("bFDungCakePile", "Fertililzer Disk Stack ", "Traditionally used as fuel in underdeveloped civilizations 6 000 000ϟ. ", Utilities.GetSprite("bFDungCakePile"), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(bFSeaWater.Info.TechType);

            _ = prefab.SetRecipe(new RecipeData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>
                {   new Ingredient(bFDryDungCakes.Info.TechType, 3),
                    

                },
               

            })

                .WithFabricatorType(More_Bioreactor_Fuels.BioFuelFabricator.BioFuel)
                .WithStepsToFabricatorTab("FBF")
                .WithCraftingTime(0.5f);



            prefab.SetGameObject(new CloneTemplate(bFDryDungCakes.Info, TechType.CreepvinePiece)
            {
                ModifyPrefab = prefab1 =>
                {
                    prefab1.EnsureComponent<Pickupable>();
                    Eatable eatable = prefab1.EnsureComponent<Eatable>();
                    eatable.foodValue = -50;
                    eatable.waterValue = -50;
                }
            });



            prefab.Register();
        }

    }
}