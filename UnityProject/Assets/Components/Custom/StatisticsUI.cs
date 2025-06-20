using UnityEngine;

#if (UNITY_EDITOR || UNITY_STANDALONE)
using Nvizzio.Game.UI.Views;
#else
using System.Reflection;
using System.Runtime.InteropServices;
using HarmonyLib;
using Il2CppInterop.Runtime;
using Il2CppNvizzio.Game.Services.Currencies;
using Il2CppNvizzio.Game.UI.Tooltip;
using Il2CppNvizzio.Game.UI.Views;
using MelonLoader;
using TowerDominionUIMod.Core;
using TowerDominionUIMod.Utils;
#endif

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