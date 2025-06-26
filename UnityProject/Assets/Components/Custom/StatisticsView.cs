using UnityEngine;

#if (UNITY_EDITOR || UNITY_STANDALONE)
#else
using Il2CppInterop.Runtime;
using Il2CppNvizzio.Game.GamePlay.Events;
using Il2CppNvizzio.Game.GamePlay.Zones;
using Il2CppInterop.Runtime.InteropTypes.Fields;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppNvizzio.Core.Messaging;
using UnityEngine.Localization;
using MelonLoader;
using TowerDominionUIMod.Core;
using TowerDominionUIMod.Utils;
#endif

namespace TowerDominionUIMod.Components.Custom
{
#if !(UNITY_EDITOR || UNITY_STANDALONE)
    [RegisterTypeInIl2Cpp]
#endif
    public class StatisticsView : MonoBehaviour
    {
#if (UNITY_EDITOR || UNITY_STANDALONE)
        [SerializeField] private GameObject body;
#else
        public Il2CppReferenceField<GameObject> body;
        private ModMessageObserver observer;
        
        private StatisticsLine neutralOdds;
#endif

#if !(UNITY_EDITOR || UNITY_STANDALONE)
        public void Start()
        {
            observer = GameUtils.RegisterGameplayEventObserver(observer, HandleMessage);
            
            neutralOdds = AddLine(
                new LocalizedString("TDUIMOD", "StatisticsNeutralOdds")
            );
        }

        private StatisticsLine AddLine(LocalizedString statisticTypeText)
        {
            StatisticsLine line = null;

            var prefab = AssetBundles.Instance.LoadPrefabSync("Prefabs/StatisticsLine", true);
            if (prefab == null) return null;

            var lineObject = Instantiate(prefab, body.Value.transform);
            line = lineObject.GetComponent<StatisticsLine>();
            line.SetLocalizedTypeText(statisticTypeText);
            line.SetValueText(UpdateNeutralOdds());
            return line;
        }

        public void HandleMessage(Il2CppSystem.IComparable message, Il2CppReferenceArray<Il2CppSystem.Object> data)
        {
            var messageType = message.Unbox<GameplayEvent>();

            switch (messageType)
            {
                case GameplayEvent.OnZonePlace:
                case GameplayEvent.GameBegin:
                case GameplayEvent.OnDiscoveringNeutral:
                case GameplayEvent.WaveBegin:
                    neutralOdds.SetValueText(UpdateNeutralOdds());
                    break;
                
                default:
                    // NOOP
                    break;
            }
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
#endif
    }
}