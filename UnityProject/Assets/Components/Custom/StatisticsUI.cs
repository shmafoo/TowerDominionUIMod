using UnityEngine;

#if (UNITY_EDITOR || UNITY_STANDALONE)
#else
using Il2CppInterop.Runtime.InteropTypes.Fields;
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
        [SerializeField]
        private StatisticsView statisticsView;
#else
        public Il2CppReferenceField<StatisticsView> statisticsView;
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