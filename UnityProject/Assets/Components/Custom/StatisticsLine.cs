using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

#if (UNITY_EDITOR || UNITY_STANDALONE)
using TMPro;
#else
using Il2CppInterop.Runtime.InteropTypes.Fields;
using Il2CppTMPro;
using MelonLoader;
using Il2CppInterop.Runtime;
using Il2CppNvizzio.Game.GamePlay.Events;
using TowerDominionUIMod.Core;
using UnityEngine.Events;
#endif

namespace TowerDominionUIMod.Components.Custom
{
#if (UNITY_EDITOR || UNITY_STANDALONE)
    public class StatisticsLine : MonoBehaviour
    {
        [SerializeField] private LocalizeStringEvent locTypeText;
        [SerializeField] private TextMeshProUGUI valueTextField;
    }
#else
    [RegisterTypeInIl2Cpp]
    public class StatisticsLine : MonoBehaviour
    {
        public Il2CppReferenceField<LocalizeStringEvent> locTypeText;
        public Il2CppReferenceField<TextMeshProUGUI> valueTextField;
        private ModMessageObserver observer;

        public void SetMessageObserver(ModMessageObserver ob)
        {
            observer = ob;
        }

        public void SetLocalizedTypeText(LocalizedString localizedString)
        {
            locTypeText.Value.OnUpdateString.AddListener(
                DelegateSupport.ConvertDelegate<UnityAction<string>>(new Action<string>(SetTypeText)));
            
            locTypeText.Value.StringReference = localizedString;
        }

        private void SetTypeText(string text)
        {
            locTypeText.Value.gameObject.GetComponent<TextMeshProUGUI>().text = text;
        }

        public void SetValueText(string value)
        {
            valueTextField.Value.text = value;
        }

        public void ForceUpdate()
        {
            var boxedEvent = Il2CppSystem.Enum.InternalBoxEnum(
                new Il2CppSystem.RuntimeType(Il2CppType.Of<GameplayEvent>().Pointer),
                (long) GameplayEvent.OnDemand
            );
            
            observer.Callback?.Invoke(boxedEvent.Cast<Il2CppSystem.IComparable>(), null);
        }

        public StatisticsLine(IntPtr ptr) : base(ptr)
        {
        }
    }
#endif
}