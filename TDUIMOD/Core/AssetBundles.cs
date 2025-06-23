using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Il2CppInterop.Runtime;
using Il2CppSystem.Collections;
using Il2CppSystem.Linq;
using MelonLoader;
using MelonLoader.Utils;
using TowerDominionUIMod.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace TowerDominionUIMod.Core;

public class AssetBundles : Il2CppSystem.Object
{
    private static readonly AssetBundles instance = new();
    public static AssetBundles Instance => instance;

    private IResourceLocator Catalog;


    public void Initialize()
    {
        Catalog = LoadCatalog("catalog_towerdominionuimod.json");

        MelonLogger.WriteLine();
        for (var i = 0; i < Catalog.Keys.Count(); i++) MelonLogger.Msg($"{Catalog.Keys.ElementAt(i).ToString()}");
        MelonLogger.WriteLine();


        var selectedLocale = LocalizationSettings.SelectedLocale;
        MelonLogger.Msg($"Selected locale: {selectedLocale.Identifier.Code}");

        foreach (var l in LocalizationSettings.AvailableLocales.Locales)
            MelonLogger.Msg($"Available locale: {l.Identifier.Code}");

        var tablesHandle = LocalizationSettings
                           .StringDatabase
                           .GetAllTables()
                           .WaitForCompletion();

        var tables = tablesHandle.Cast<Il2CppSystem.Collections.Generic.List<StringTable>>();
        foreach (var table in tables)
            MelonLogger.Msg($"{table.TableCollectionName}: {table.Count} entries");
    }

    private IResourceLocator LoadCatalog(string catalogName)
    {
        var catalogPath = Path.Combine(MelonEnvironment.ModsDirectory, catalogName);
        var handle = Addressables.LoadContentCatalogAsync(catalogPath, true);

        var locator = handle.WaitForCompletion();

        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            MelonLogger.Error($"Failed to load content catalog at {catalogPath}");
            MelonLogger.Error($"Exception: {handle.OperationException.Message}");
        }

        MelonLogger.Msg($"Loaded content catalog at {catalogPath}");

        return locator;
    }

    public GameObject LoadPrefabSync(string assetAddress, bool tryForceLoad = false)
    {
        var handle = Addressables.LoadAssetAsync<GameObject>(assetAddress);
        var prefab = handle.WaitForCompletion();

        if (handle.Status == AsyncOperationStatus.Succeeded) return prefab;

        if (!tryForceLoad)
        {
            MelonLogger.Error($"Error while loading Prefab \"{assetAddress}\"");
            MelonLogger.Error($"Exception: {handle.OperationException.Message}");
        }

        return tryForceLoad ? TryForceLoadPrefab(assetAddress) : null;
    }

    private GameObject TryForceLoadPrefab(string assetAddress)
    {
        // Get a managed list of resource locators
        var managedLocatorList = Addressables.ResourceLocators.ToSystemList();

        // Get the bundle the asset saved in
        var bundlePath = managedLocatorList.GetBundlePath(assetAddress);

        // Try to actually load the prefab from the found bundle
        return LoadFromBundle(assetAddress, bundlePath);
    }

    private GameObject LoadFromBundle(string assetAddress, string bundlePath = null)
    {
        if (bundlePath == null)
        {
            MelonLogger.Error(
                $"Could not load asset \"{assetAddress}\" from catalog and bundle was not found for fallback.");
            return null;
        }

        // For local loading, we need to get rid of the "protocoll"
        bundlePath = bundlePath.StartsWith("file://") ? bundlePath.Substring(7) : bundlePath;

        var bundle = AssetBundle.LoadFromFile(bundlePath);

        if (bundle == null)
        {
            MelonLogger.Error($"Could not load bundle at \"{bundlePath}\" to load \"{assetAddress}\"");
            return null;
        }

        var assetName = bundle.GetAllAssetNames()
                              .FirstOrDefault(name => name.Contains(assetAddress));

        if (assetName == null)
        {
            MelonLogger.Error($"Could not find asset \"{assetAddress}\" in bundle {bundlePath}");
            return null;
        }

        var prefab = bundle.LoadAsset<GameObject>(assetName);
        if (prefab != null)
        {
            MelonLogger.Warning($"Could not load asset \"{assetAddress}\" from catalog.");
            MelonLogger.Warning($"{assetName} was loaded with possible broken references.");
        }
        else
        {
            MelonLogger.Error($"Could not load asset \"{assetAddress}\" directly from bundle.");
        }

        return prefab;
    }
}