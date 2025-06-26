using UnityEngine;

#if (UNITY_EDITOR || UNITY_STANDALONE)
#else
using Il2CppNvizzio.Game.GamePlay.Events;
using Il2CppNvizzio.Game.GamePlay.Zones;
using Il2CppInterop.Runtime.InteropTypes.Fields;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
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

        public void Start()
        {
            neutralOdds = AddLine(
                ModUtils.GetLocalizedString("StatisticsNeutralOdds"),
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
        }

        private StatisticsLine AddLine(LocalizedString statisticTypeText, List<GameplayEvent> observedEvents = null)
        {
            StatisticsLine line = null;

            var prefab = AssetBundles.Instance.LoadPrefabSync("Prefabs/StatisticsLine", true);
            if (prefab == null) return null;
            var lineObject = Instantiate(prefab, body.Value.transform);
            
            line = lineObject.GetComponent<StatisticsLine>();
            line.SetMessageObserver(GameUtils.RegisterGameplayEventObserver(HandleNaturalOdds, observedEvents));
            line.SetLocalizedTypeText(statisticTypeText);
            line.SetValueText(UpdateNeutralOdds());
            
            return line;
        }

        public void HandleNaturalOdds(Il2CppSystem.IComparable message, Il2CppReferenceArray<Il2CppSystem.Object> data)
        {
            var messageType = message.Unbox<GameplayEvent>();
            neutralOdds.SetValueText(UpdateNeutralOdds());
        }

        private string UpdateNeutralOdds()
        {
            var oddsCurrent = ZoneManager.Instance.currentNeutralOdds;
            var oddsIncrease = ZoneManager.Instance.neutralIncrementOdds;

            return $"{oddsCurrent} [+{oddsIncrease}]";
        }

        public StatisticsView(IntPtr ptr) : base(ptr)
        {
        }
    }
#endif
}