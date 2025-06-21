using HarmonyLib;
using Il2CppNvizzio.Game.GamePlay.Events;
using Il2CppNvizzio.Game.GamePlay.GameEntities;
using Il2CppNvizzio.Game.GamePlay.Zones;
using MelonLoader;

namespace TowerDominionUIMod.Patches;

[HarmonyPatch(typeof(EntityManager))]
internal static class EntityManager_Patch
{
    [HarmonyPatch(nameof(EntityManager.HandleGameEvent))]
    [HarmonyPrefix]
    private static void HandleGameEvent(GameplayEvent message)
    {
        // MelonLogger.Msg($"GameEvent: {message}");

        if (message == GameplayEvent.OnPathUpdated)
        {
            var oddsCurrent = ZoneManager.Instance.currentNeutralOdds;
            var oddsIncrease = ZoneManager.Instance.neutralIncrementOdds;
            var oddsReset = ZoneManager.Instance.neutralResetOddsPct;

            MelonLogger.Msg($"Odds: C-{oddsCurrent} / I-{oddsIncrease} / R-{oddsReset}");
        }
    }
}