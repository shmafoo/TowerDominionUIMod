using HarmonyLib;
using Il2CppNvizzio.Game.UI;
using Il2CppTMPro;
using UnityEngine;

/// <summary>
/// Provides a Harmony patch for the VersionNumberUI component to display mod information
/// on the main menu screen. This patch extends the version number display to include
/// a mod indicator alongside the original game version.
/// </summary>
/// <remarks>
/// The patch modifies the version number display by:
/// <list type="bullet">
/// <item><description>Adding a mod indicator text prefix</description></item>
/// <item><description>Preserving the original game version information</description></item>
/// <item><description>Adjusting the UI component size to accommodate the additional text</description></item>
/// </list>
/// </remarks>
namespace TowerDominionUIMod.Patches
{
    [HarmonyPatch(typeof(VersionNumberUI))]
    internal static class VersionNumberUI_Patch
    {
        /// <summary>
        /// Postfix patch for the Start method of VersionNumberUI that modifies the version text
        /// to include mod information and adjusts the component size for proper display.
        /// </summary>
        /// <param name="__instance">The instance of VersionNumberUI being patched</param>
        [HarmonyPostfix, HarmonyPatch(nameof(VersionNumberUI.Start))]
        private static void Start_Postfix(VersionNumberUI __instance)
        {
            var versionUi = __instance.GetComponent<TextMeshProUGUI>();
            versionUi.text = $"This might be a mod | Game: {versionUi.text}";
            
            // Stretch the text component or the text won't fit
            __instance.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 100);
        }
    }
}