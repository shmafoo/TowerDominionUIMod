using System;
using MelonLoader;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TowerDominionUIMod.Core;

public class ModOverlay
{
    private static readonly ModOverlay instance = new();
    public static ModOverlay Instance => instance;

    private GameObject Overlay = null;

    public void Initialize()
    {
        if (Overlay != null)
            return;

        var prefab = AssetBundles.LoadPrefabSync("Prefabs/ModHUD");

        Overlay = Object.Instantiate(prefab);
        Overlay.SetActive(false);
        MelonLogger.Msg($"Overlay {Overlay.name} created in scene {Overlay.scene.name}");

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
        MelonLogger.Msg($"Showing overlay {Overlay.active}");
        Overlay?.SetActive(true);
    }

    private void HideOverlay()
    {
        MelonLogger.Msg($"Hiding overlay {Overlay.active}");
        Overlay?.SetActive(false);
    }
}