using System;
using System.IO;
using Il2Cpp;
using MelonLoader;
using MelonLoader.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TowerDominionUIMod.Core
{
    public class ModOverlay
    {
        private static readonly ModOverlay instance = new();
        public static ModOverlay Instance => instance;

        private GameObject Overlay = null;
        public GameObject Windows = null;
        public GameObject TopPanel = null;

        public void Initialize()
        {
            if (Overlay != null)
                return;

            var prefab = AssetBundles.Instance.LoadPrefabSync("Prefabs/ModHUD", true);

            // var path = Path.Combine(MelonEnvironment.ModsDirectory, "towerdominionuimod-prefabs_assets_all.bundle");
            // var prefab = AssetBundles.Instance.LoadFromBundle(
            //     "Prefabs/ModHUD",
            //     path
            // );
            //
            // var prefab2 = AssetBundles.Instance.LoadFromBundle(
            //     "Prefabs/StatisticsLine",
            //     path
            // );

            if (!prefab)
                return;

            Overlay = Object.Instantiate(prefab);
            Overlay?.SetActive(false);

            Windows = Overlay?.transform.FindChildByName("Windows").gameObject;
            TopPanel = Overlay?.transform.FindChildByName("TopPanel").gameObject;

            SetupEvents();
        }

        public void Cleanup()
        {
            UnsubscribeEvents();
        }

        private void SetupEvents()
        {
            ModEvents.OnShowModOverlay += ShowOverlay;
            ModEvents.OnHideModOverlay += HideOverlay;
        }

        private void UnsubscribeEvents()
        {
            ModEvents.OnShowModOverlay -= ShowOverlay;
            ModEvents.OnHideModOverlay -= HideOverlay;
        }

        private void ShowOverlay()
        {
            Overlay?.SetActive(true);
        }

        private void HideOverlay()
        {
            Overlay?.SetActive(false);
        }
    }
}