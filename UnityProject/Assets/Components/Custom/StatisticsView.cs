using UnityEngine;
using UnityEngine.Localization;

#if (UNITY_EDITOR || UNITY_STANDALONE)
using Nvizzio.Game.UI.Views;
#else
using Il2CppInterop.Runtime.InteropTypes.Fields;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
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
        [SerializeField] private GameObject body;
#else
        public Il2CppReferenceField<GameObject> body;
#endif
        
        public void Start()
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            var odds = AddLine(
                new LocalizedString("TDUIMOD", "StatisticsNaturalOdds")
                );
#endif
        }
        
        private GameObject AddLine(LocalizedString statisticTypeText)
        {
            GameObject prefab = null;
            
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            prefab = AssetBundles.Instance.LoadPrefabSync("Prefabs/StatisticsLine", true);
            if (prefab == null) return null;
            
            var lineObject = Instantiate(prefab, body.Value.transform);
            var line = lineObject.GetComponent<StatisticsLine>();
            line.SetLocalizedTypeText(statisticTypeText);
            line.SetValueText("0");
#endif
            return prefab;
        }

        public void HandleMessage(Il2CppSystem.IComparable message, Il2CppReferenceArray<Il2CppSystem.Object> data)
        {
        }
        
#if !(UNITY_EDITOR || UNITY_STANDALONE)
        public StatisticsView(IntPtr ptr) : base(ptr)
        {
        }
#endif
    }
}