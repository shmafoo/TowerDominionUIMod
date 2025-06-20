using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using HarmonyLib;
using Il2CppInterop.Runtime;
using Il2CppNvizzio.Core.Localization;
using Il2CppSystem.Resources;
using UnityEngine;
using MelonLoader;
using MelonLoader.Utils;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.Util;

namespace TowerDominionUIMod.Core
{
    public static class AssetBundles
    {
        public static readonly AssetBundle ModBundle;
        public static readonly StringTable ModLocalization; 
        // public static readonly SharedTableData ModLocalizationSharedData;

        static AssetBundles()
        {
            LoadBundle(ref ModBundle, "towerdominionuimod-assetbundle");
            LoadAndAddModLocalization();
        }
        
        private static IResourceLocator LoadAndAddModLocalization()
        {
            var handle = Addressables.LoadContentCatalogAsync(
                Path.Combine(MelonEnvironment.ModsDirectory, "catalog.json"),
                false
            );
            
            var locator = handle.WaitForCompletion();
            return locator;
        }
        
        private static bool LoadBundle(ref AssetBundle bundle, string name)
        {
            string bundlePath = Path.Combine(MelonEnvironment.ModsDirectory, name);

            if (File.Exists(bundlePath))
            {
                bundle = AssetBundle.LoadFromFile(bundlePath);

                if (!bundle)
                {
                    MelonLogger.Error("Failed to load AssetBundle.");
                    return false;
                }
            }
            else
            {
                MelonLogger.Error($"AssetBundle not found at: {bundlePath}");
                return false;
            }

            MelonLogger.Msg($"Loaded asset bundle {name}");
            return true;
        }
        
        public static GameObject LoadGameObject(AssetBundle bundle, string path)
        {
            try
            {
                var prefab = bundle.LoadAsset<GameObject>(path);
            
                if (!prefab)
                    MelonLogger.Error($"Prefab \"{path}\" not found");
            
                return prefab;  
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}