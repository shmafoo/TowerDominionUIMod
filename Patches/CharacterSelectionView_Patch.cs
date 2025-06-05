using HarmonyLib;
using Il2CppNvizzio.Game.UI.Views;
using MelonLoader;
using TowerDominionUIMod.ViewMods;
using TowerDominionUIMod.Core;

/// <summary>
/// Provides Harmony patches for the CharacterSelectionView to support the SelectAll button functionality
/// in the ExpertMode view. These patches handle the state management of the SelectAll button by
/// monitoring navigation between normal and expert mode views.
/// </summary>
/// <remarks>
/// The patches in this class:
/// <list type="bullet">
/// <item><description>Monitor transitions between normal and expert mode views</description></item>
/// <item><description>Manage the visibility of the SelectAll button</description></item>
/// <item><description>Ensure proper cleanup when leaving the expert mode view</description></item>
/// </list>
/// </remarks>
namespace TowerDominionUIMod.Patches
{
    [HarmonyPatch(typeof(CharacterSelectionView))]
    internal class CharacterSelectionView_Patch
    {
        /// <summary>
        /// Postfix patch for the Next button click handler. Shows the SelectAll button when
        /// entering the expert mode view.
        /// </summary>
        /// <param name="__instance">The instance of CharacterSelectionView being patched</param>
        [HarmonyPostfix, HarmonyPatch(nameof(CharacterSelectionView.OnClickNextButton))]
        private static void OnClickNextButton_Postfix(CharacterSelectionView __instance)
        {
            if (!ViewModRegistry.TryGetModifier("CharacterSelectionView", out var modifier))
            {
                MelonLogger.Error("Could not find CharacterSelectionView modifier");
                return;
            }
            
            (modifier as CharacterSelectionViewMod).ExpertModeViewEntered();
        }
        
        /// <summary>
        /// Postfix patch for the Previous button click handler. Hides the SelectAll button when
        /// returning to the normal view.
        /// </summary>
        /// <param name="__instance">The instance of CharacterSelectionView being patched</param>
        [HarmonyPostfix, HarmonyPatch(nameof(CharacterSelectionView.OnClickPreviousButton))]
        private static void OnClickPreviousButton_Postfix(CharacterSelectionView __instance)
        {
            if (!ViewModRegistry.TryGetModifier("CharacterSelectionView", out var modifier))
            {
                MelonLogger.Error("Could not find CharacterSelectionView modifier");
                return;
            }
            
            (modifier as CharacterSelectionViewMod).ExpertModeViewClosed();
        }
        
        /// <summary>
        /// Postfix patch for the Start button click handler. Ensures the SelectAll button is hidden
        /// when starting the game.
        /// </summary>
        /// <param name="__instance">The instance of CharacterSelectionView being patched</param>
        [HarmonyPostfix, HarmonyPatch(nameof(CharacterSelectionView.OnClickStartButton))]
        private static void OnClickStartButton_Postfix(CharacterSelectionView __instance)
        {   
            if (!ViewModRegistry.TryGetModifier("CharacterSelectionView", out var modifier))
            {
                MelonLogger.Error("Could not find CharacterSelectionView modifier");
                return;
            }
            
            (modifier as CharacterSelectionViewMod).ExpertModeViewClosed();
        }
    }
}