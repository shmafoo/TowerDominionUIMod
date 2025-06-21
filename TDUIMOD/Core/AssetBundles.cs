using System.IO;
using MelonLoader;
using MelonLoader.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TowerDominionUIMod.Core;

public static class AssetBundles
{
    private static IResourceLocator Catalog;

    public static void Initialize()
    {
        Catalog = LoadCatalog("catalog_towerdominionuimod.json");
    }

    private static IResourceLocator LoadCatalog(string catalogName)
    {
        var catalogPath = Path.Combine(MelonEnvironment.ModsDirectory, catalogName);
        var handle = Addressables.LoadContentCatalogAsync(catalogPath);
        var locator = handle.WaitForCompletion();

        if (handle.Status != AsyncOperationStatus.Succeeded || locator == null)
        {
            MelonLogger.Error($"Failed to load content catalog at {catalogPath}");
            MelonLogger.Error($"Exception: {handle.OperationException.Message}");
            return null;
        }

        return locator;
    }

    public static GameObject LoadPrefabSync(string assetAddress)
    {
        var handle = Addressables.LoadAssetAsync<GameObject>(assetAddress);
        var prefab = handle.WaitForCompletion();

        if (handle.Status != AsyncOperationStatus.Succeeded || prefab == null)
        {
            MelonLogger.Error($"Failed to load prefab with address {assetAddress}");
            MelonLogger.Error($"Exception: {handle.OperationException.Message}");
            return null;
        }

        return prefab;
    }
}