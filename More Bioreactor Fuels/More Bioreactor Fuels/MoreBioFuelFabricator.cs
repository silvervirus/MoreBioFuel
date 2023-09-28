using BepInEx;
using HarmonyLib;
using More_Bioreactor_Fuels.AdvencedFuel;
using More_Bioreactor_Fuels.LockForever;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static CraftData;

namespace More_Bioreactor_Fuels
{
    [BepInPlugin(BioFuelFabricator.PLUGIN_GUID, BioFuelFabricator.PLUGIN_NAME, BioFuelFabricator.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus", BepInDependency.DependencyFlags.HardDependency)]
    public class BioFuelFabricator : BaseUnityPlugin
    {
        public const String PLUGIN_GUID = "MoreBioFuel";
        public const String PLUGIN_NAME = "BioFuel_SN";
        public const String PLUGIN_VERSION = "1.0.0";
       
        public static CraftTree.Type BioFuel;

        private static readonly Harmony harmony = new Harmony(PLUGIN_GUID);

        public void Awake()


        {
            // Bioreactor Numbers For the mod
            BaseBioReactor.charge[bFAmmonia.Info.TechType] = 11000f;
            BaseBioReactor.CanAdd(bFAmmonia.Info.TechType);
            BaseBioReactor.charge[bFDryDung.Info.TechType] = 7000f;
            BaseBioReactor.CanAdd(bFDryDung.Info.TechType);
            BaseBioReactor.charge[bFDryDungCakes.Info.TechType] = 1000000f;
            BaseBioReactor.CanAdd(bFDryDungCakes.Info.TechType);
            BaseBioReactor.charge[bFDungCake.Info.TechType] = 100000f;
            BaseBioReactor.CanAdd(bFDungCake.Info.TechType);
            BaseBioReactor.charge[bFDungCakePile.Info.TechType] = 6000000f;
            BaseBioReactor.CanAdd(bFDungCakePile.Info.TechType);

            var prefab1 = new CustomPrefab("BioFuelFabricator", "Bio Fuel Fabricator", "Highly Processed Resources To increase power given to the BioReactor", Utilities.GetSprite("bFBioFuels"));
            var fabTree1 = prefab1.CreateFabricator(out CraftTree.Type GetGood);
            var model = new FabricatorTemplate(prefab1.Info, GetGood)
            {
                FabricatorModel = FabricatorTemplate.Model.MoonPool,
                ModifyPrefab = go =>
                {
                    var renderer = go.GetComponentInChildren<SkinnedMeshRenderer>(true);


                }
            };
            prefab1.SetGameObject(model);
            prefab1.SetRecipe(new RecipeData(new Ingredient(TechType.Titanium, 2), new Ingredient(TechType.CrashPowder, 2), new Ingredient(TechType.Battery, 1), new Ingredient(TechType.ComputerChip, 1)));
            prefab1.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);
            prefab1.SetUnlock(TechType.Seamoth);
            prefab1.Register();

            //Crafttree nodes 
            CraftTreeHandler.AddTabNode(GetGood, "LB", "Laboratory Equipment", SpriteManager.Get(TechType.LabEquipment1));
            CraftTreeHandler.AddTabNode(GetGood, "BE", "Bioengineering", Utilities.GetSprite("bFBioengineering"));
            CraftTreeHandler.AddTabNode(GetGood, "BAF", "Advanced Fuels", Utilities.GetSprite("bFAdvancedFuels"));
            CraftTreeHandler.AddTabNode(GetGood, "ABM", "Animal Biomass", Utilities.GetSprite("bFAnimalBiomass"));
            CraftTreeHandler.AddTabNode(GetGood, "PBM", "Plant Biomass", Utilities.GetSprite("bFPlantBiomass"));
            CraftTreeHandler.AddTabNode(GetGood, "FTN", "Fermentation", Utilities.GetSprite("bFFermentation"));
            CraftTreeHandler.AddTabNode(GetGood, "BLD", "Basic Liquids", Utilities.GetSprite("bFBasicLiquids"));
            CraftTreeHandler.AddTabNode(GetGood, "FBF", "Fertilizer BioFuel", SpriteManager.Get(TechType.SeaTreaderPoop));
            CraftTreeHandler.AddTabNode(GetGood, "BFF", "Food", SpriteManager.Get(TechType.Peeper));
            
           

            //Patched items
            BioFuel = GetGood;
            harmony.PatchAll();
            Main.FindPiracy();
            bFAmmonia.Patch();
            bFAnammoxBacteria.Patch();
            bFBiodieselBarrel.Patch();
            bFBladderfishDNA.Patch();
            bFBloodspadefishEgg.Patch();
            bFBODistilledWater.Patch();
            bFBOPlantOil.Patch();
            bFCODistilledWater.Patch();
            bFCOPlantOil.Patch();
            bFDungCake.Patch();
            bFDryDung.Patch();
            bFLeviathanDNA.Patch();
            bFFatspadeDNA.Patch();
            bFCrabsquidDNA.Patch();
            bFWetspadeDNA.Patch();
            bFFatspade.Patch();
            bFWetspade.Patch();
            bFOptimuspade.Patch();
            bFYeast.Patch();
            bFTallow.Patch();
            bFTallowBarrel.Patch();
            bFSampleAnalyzer.Patch();
            bFSeaWater.Patch();
            bFPowerSupplyCell.Patch();
            bFHydrazineCan.Patch();
            bFHydrazinePowerCell.Patch();
            bFMicroscope.Patch();
            bFLithiumPowerCell.Patch();
            bFFluidAnalyzer.Patch();
            bFDryDung0.Patch();
            bFDryDungCakes0.Patch();
            bFDungCakePile.Patch();
            bFDungCake0.Patch();
            bFSeaWaterFromKooshChunk.Patch();
            bFSeaWaterFromPurpleTentacleSeed.Patch();
            bFCookedFatspade.Patch();
            bFCookedOptimuspade.Patch();
            bFCookedWetspade.Patch();
            bFCuredFatspade.Patch();
            bFCuredOptimuspade.Patch();
            bFCuredWetspade.Patch();

            
            

        }




    }
}



