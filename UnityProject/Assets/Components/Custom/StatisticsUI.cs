#if (UNITY_EDITOR || UNITY_STANDALONE)
using Nvizzio.Game.UI.Views;
#else
using Il2CppNvizzio.Game.UI.Tooltip;
using MelonLoader;
#endif
using UnityEngine;

namespace TowerDominionUIMod.Components.Custom
{
#if !(UNITY_EDITOR || UNITY_STANDALONE)
    [RegisterTypeInIl2Cpp]
#endif
    public class StatisticsUI : MonoBehaviour
    {
#if (UNITY_EDITOR || UNITY_STANDALONE)
#else
        public SimpleTooltipData tooltipData;
#endif

        public void Awake()
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            tooltipData = GetComponent<SimpleTooltipData>();
#endif
        }

        public void OnButtonClicked()
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            MelonLogger.Msg("Button clicked!");
#endif
        }
    }
}