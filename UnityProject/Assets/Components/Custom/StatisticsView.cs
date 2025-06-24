using UnityEngine;
using UnityEngine.Localization;

#if (UNITY_EDITOR || UNITY_STANDALONE)
#else
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Fields;
using MelonLoader;
using System;
using TowerDominionUIMod.Core;
#endif

namespace TowerDominionUIMod.Components.Custom
{
#if !(UNITY_EDITOR || UNITY_STANDALONE)
    [RegisterTypeInIl2Cpp]
#endif
    public class StatisticsView : MonoBehaviour
    {
#if (UNITY_EDITOR || UNITY_STANDALONE)
        [SerializeField] private RectTransform root;

        [SerializeField] private StyledButton closeButton;

        [SerializeField] private Transform body;
#else
        public Il2CppReferenceField<RectTransform> root;
        public Il2CppReferenceField<StyledButton> closeButton;
        public Il2CppReferenceField<Transform> body;
#endif

        public void Start()
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            MelonLogger.Msg("StatisticsView.Start() called!");

            var odds = AddLine(
                new LocalizedString("TDUIMOD", "StatisticsNaturalOdds")
                );
#endif
        }
        
        private GameObject AddLine(LocalizedString statisticTypeText)
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            var prefab = AssetBundles.Instance.LoadPrefabSync("Prefabs/StatisticsLine", true);
            
            return prefab != null ? Instantiate(prefab, transform.FindChildByName("Body")) : null;
#else
            return null;
#endif
        }

#if !(UNITY_EDITOR || UNITY_STANDALONE)
        public StatisticsView(IntPtr ptr) : base(ptr)
        {
        }
#endif
    }
}