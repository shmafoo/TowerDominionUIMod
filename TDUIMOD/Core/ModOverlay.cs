using UnityEngine;

namespace TowerDominionUIMod.Core;

public static class ModOverlay
{
    private static GameObject Overlay = null;

    public static void Initialize()
    {
        if (Overlay != null)
            return;

        Overlay = AssetBundles.LoadPrefabSync("");
    }
}