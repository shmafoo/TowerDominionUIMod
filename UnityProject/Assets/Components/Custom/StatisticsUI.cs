using UnityEngine;

#if (UNITY_EDITOR || UNITY_STANDALONE)
using Nvizzio.Game.UI.Tooltip;
#else
using Il2CppInterop.Runtime.InteropTypes.Fields;
using Il2CppNvizzio.Game.UI.Tooltip;
using MelonLoader;
using System;
#endif

namespace TowerDominionUIMod.Components.Custom
{
#if !(UNITY_EDITOR || UNITY_STANDALONE)
    [RegisterTypeInIl2Cpp]
#endif
    public class StatisticsUI : MonoBehaviour
    {
#if (UNITY_EDITOR || UNITY_STANDALONE)
        [SerializeField] private StatisticsView statisticsView;
        [SerializeField] private UniversalTooltipTrigger tooltip;
#else
        public Il2CppReferenceField<StatisticsView> statisticsView;
        public Il2CppReferenceField<UniversalTooltipTrigger> tooltip;
#endif

        public void OnButtonClicked()
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            statisticsView.Value.gameObject.SetActive(!statisticsView.Value.gameObject.active);
#endif
        }

#if !(UNITY_EDITOR || UNITY_STANDALONE)
        public StatisticsUI(IntPtr ptr) : base(ptr)
        {
        }
#endif
    }
}