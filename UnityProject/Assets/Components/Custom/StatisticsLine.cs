using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

#if (UNITY_EDITOR || UNITY_STANDALONE)
using TMPro;
#else
using Il2CppInterop.Runtime.InteropTypes.Fields;
using Il2CppTMPro;
using MelonLoader;
using System;
using Il2CppInterop.Runtime;
using UnityEngine.Events;
#endif

namespace TowerDominionUIMod.Components.Custom
{
#if !(UNITY_EDITOR || UNITY_STANDALONE)
    [RegisterTypeInIl2Cpp]
#endif
    public class StatisticsLine : MonoBehaviour
    {
#if (UNITY_EDITOR || UNITY_STANDALONE)
        [SerializeField] private LocalizeStringEvent locTypeText;
        [SerializeField] private TextMeshProUGUI valueTextField;
#else
        public Il2CppReferenceField<LocalizeStringEvent> locTypeText;
        public Il2CppReferenceField<TextMeshProUGUI> valueTextField;
#endif

        public void SetLocalizedTypeText(LocalizedString localizedString)
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            var test = localizedString.GetLocalizedString();
            MelonLogger.Msg($"SetLocalizedTypeText with value \"{test}\"");

            locTypeText.Value.OnUpdateString.AddListener(
                DelegateSupport.ConvertDelegate<UnityAction<string>>(new Action<string>(SetTypeText)));
            locTypeText.Value.StringReference = localizedString;
#endif
        }

        private void SetTypeText(string text)
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            locTypeText.Value.gameObject.GetComponent<TextMeshProUGUI>().text = text;
#endif
        }

        public void SetValueText(string value)
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            valueTextField.Value.text = value;
#endif
        }

#if !(UNITY_EDITOR || UNITY_STANDALONE)
        public StatisticsLine(IntPtr ptr) : base(ptr)
        {
        }
#endif
    }
}