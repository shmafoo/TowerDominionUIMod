using UnityEngine;

#if (UNITY_EDITOR || UNITY_STANDALONE)
#else
using IntPtr = System.IntPtr;
using Il2CppSystem;
using Il2Cpp;
using Il2CppNvizzio.Game.GamePlay.Events;
using Il2CppNvizzio.Game.GamePlay.Zones;
using Il2CppInterop.Runtime.InteropTypes.Fields;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppNvizzio.Game.Services;
using UnityEngine.Localization;
using MelonLoader;
using TowerDominionUIMod.Core;
using TowerDominionUIMod.Utils;
#endif

namespace TowerDominionUIMod.Components.Custom
{
#if (UNITY_EDITOR || UNITY_STANDALONE)
    public class StatisticsView : MonoBehaviour
    {
        [SerializeField] private GameObject body;
    }
#else
    [RegisterTypeInIl2Cpp]
    public class StatisticsView : MonoBehaviour
    {
        public Il2CppReferenceField<GameObject> body;
        private StatisticsLine neutralOdds;
        private StatisticsLine hqBaseHp;
        private StatisticsLine hqHPMultiplier;

        public void Start()
        {
            neutralOdds = AddLine(
                ModUtils.GetLocalizedString("StatisticsNeutralOdds"),
                HandleNaturalOdds,
                new List<GameplayEvent>
                {
                    GameplayEvent.OnZonePlace,
                    GameplayEvent.GameBegin,
                    GameplayEvent.OnDiscoveringNeutral,
                    GameplayEvent.WaveBegin,
                    GameplayEvent.OnBuildingPlace,
                    GameplayEvent.OnBuildingRemove,
                }
            );

            hqBaseHp = AddLine(
                ModUtils.GetLocalizedString("StatisticsHQBaseHP"),
                HandleHQBaseHP,
                new List<GameplayEvent>
                {
                    GameplayEvent.GameBegin,
                    GameplayEvent.WaveBegin,
                    GameplayEvent.OnBuildingPlace,
                    GameplayEvent.OnBuildingRemove,
                    GameplayEvent.HQDataInitialized,
                    GameplayEvent.RoundBegin
                }
            );

            hqHPMultiplier = AddLine(
                ModUtils.GetLocalizedString("StatisticsHQHPMultiplier"),
                HandleHQHPMultiplier,
                new List<GameplayEvent>
                {
                    GameplayEvent.GameBegin,
                    GameplayEvent.WaveBegin,
                    GameplayEvent.OnBuildingPlace,
                    GameplayEvent.OnBuildingRemove,
                    GameplayEvent.HQDataInitialized,
                    GameplayEvent.RoundBegin
                }
            );
            
            neutralOdds.ForceUpdate();
            hqBaseHp.ForceUpdate();
            hqHPMultiplier.ForceUpdate();
        }

        private StatisticsLine AddLine(LocalizedString statisticTypeText, ModMessageObserver.MessageCallback callback, List<GameplayEvent> observedEvents = null)
        {
            StatisticsLine line = null;

            var prefab = AssetBundles.Instance.LoadPrefabSync("Prefabs/StatisticsLine", true);
            if (prefab == null) return null;
            var lineObject = Instantiate(prefab, body.Value.transform);
            
            line = lineObject.GetComponent<StatisticsLine>();
            line.SetMessageObserver(GameUtils.RegisterGameplayEventObserver(callback, observedEvents));
            line.SetLocalizedTypeText(statisticTypeText);
            
            return line;
        }

        public void HandleNaturalOdds(Il2CppSystem.IComparable message, Il2CppReferenceArray<Il2CppSystem.Object> data)
        {
            // var messageType = message.Unbox<GameplayEvent>();
            neutralOdds.SetValueText(UpdateNeutralOdds());
        }

        public void HandleHQBaseHP(Il2CppSystem.IComparable message, Il2CppReferenceArray<Il2CppSystem.Object> data)
        {
            hqBaseHp.SetValueText(UpdateHQBaseHP());
        }

        public void HandleHQHPMultiplier(Il2CppSystem.IComparable message,
            Il2CppReferenceArray<Il2CppSystem.Object> data)
        {
            hqHPMultiplier.SetValueText(UpdateHQHPMultiplier());
        }

        private string UpdateNeutralOdds()
        {
            var oddsCurrent = ZoneManager.Instance.currentNeutralOdds;
            var oddsIncrease = ZoneManager.Instance.neutralIncrementOdds;

            return $"{oddsCurrent} [+{oddsIncrease}]";
        }

        private string UpdateHQBaseHP()
        {
            var baseValue = Services.GameRoundService.HQ.MaxHpEffectValue.BaseValue;
            var rawMod = Services.GameRoundService.HQ.MaxHpEffectValue.RawModifier;
            return $"{baseValue + rawMod}";
        }

        private string UpdateHQHPMultiplier()
        {
            return $"{Services.GameRoundService.HQ.MaxHpEffectValue.PctModifier}%";
        }
        
        public StatisticsView(IntPtr ptr) : base(ptr)
        {
        }
    }
#endif
}