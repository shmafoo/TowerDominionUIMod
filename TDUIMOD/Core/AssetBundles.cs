using MelonLoader;
using MelonLoader.Utils;
using TowerDominionUIMod.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TowerDominionUIMod.Core
{
    public class AssetBundles : Il2CppSystem.Object
    {
        private static readonly AssetBundles instance = new();
        public static AssetBundles Instance => instance;

        private IResourceLocator Catalog;


        public void Initialize()
        {
            Catalog = LoadCatalog("catalog_towerdominionuimod.json");
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

            Addressables.Release(handle);

            MelonLogger.Msg($"Loaded content catalog at {catalogPath}");

            return locator;
        }

        public GameObject LoadPrefabSync(string assetAddress, bool tryForceLoad = false)
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(assetAddress);
            var prefab = handle.WaitForCompletion();
            var status = handle.Status;
            Addressables.Release(handle);

            if (status == AsyncOperationStatus.Succeeded) return prefab;

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

            AssetBundle bundle = null;
            bundle = AssetBundle.LoadFromFile(bundlePath);

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
                MelonLogger.Warning($"{assetName} was loaded with possible broken references.");
            else
                MelonLogger.Error($"Could not load asset \"{assetAddress}\" directly from bundle.");

            // UNLOADING THE BUNDLE HERE IS IMPORTANT
            bundle.Unload(false);

            return prefab;
        }
    }
}