using MelonLoader;
using TowerDominionUIMod.Core;
using UnityEngine;

namespace TowerDominionUIMod.ViewMods
{
    [ViewName("PersistentGameHUDView")]
    public class PersistentGameHUDViewMod : ModifiedViewBase
    {
        protected override void OnModify()
        {
            AlwaysModify = false;

            var statisticsUiPrefab = AssetBundles.LoadGameObject(AssetBundles.ModBundle, "assets/prefabs/statisticsui.prefab");
            GameObject go = Object.Instantiate(statisticsUiPrefab);
            
            var rightPanel = GameObject.Find("Canvas(Clone)/Views/OverlayHUD/PersistentGameHudView(Clone)/Header/RightPanel");
            if (!rightPanel)
            {
                MelonLogger.Error($"Right panel not found in PersistentGameHUDView");
                return;
            }
            
            GameObject statisticsUi = Object.Instantiate(statisticsUiPrefab, rightPanel.transform);
            statisticsUi.name = "StatisticsUI";
        }
    }
}