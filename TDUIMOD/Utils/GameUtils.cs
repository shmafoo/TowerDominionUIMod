using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppNvizzio.Core.Messaging;
using Il2CppNvizzio.Game.GamePlay.Events;
using Il2CppTMPro;
using MelonLoader;
using TowerDominionUIMod.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace TowerDominionUIMod.Utils
{
    public static class GameUtils
    {
        public static GameObject InstantiateButton(string name, LocalizedString buttonText, Transform parent,
            Vector3? position = null)
        {
            var buttonPrefab = Resources.Load<GameObject>("prefabs/ui/BaseButton");
            if (!buttonPrefab)
            {
                MelonLogger.Error("Button Prefab not found");
                return null;
            }

            var buttonInstance = UnityEngine.Object.Instantiate(buttonPrefab, parent);
            buttonInstance.active = false;
            buttonInstance.name = name;
            buttonInstance.transform.position = position ?? Vector3.zero;

            var buttonTextComponent = buttonInstance.GetComponentInChildren<TextMeshProUGUI>();
            if (!buttonTextComponent)
            {
                MelonLogger.Error("Could not find text on button");
                return buttonInstance;
            }

            buttonTextComponent.text = buttonText.GetLocalizedString();
            return buttonInstance;
        }

        public static ModMessageObserver RegisterGameplayEventObserver(ModMessageObserver observer, ModMessageObserver.MessageCallback callback)
        {
            observer = new ModMessageObserver();
            observer.SetCallback(callback);
            
            Il2CppReferenceArray<Il2CppSystem.Type> messageTypes = new Il2CppReferenceArray<Il2CppSystem.Type>(1);
            messageTypes[0] = Il2CppType.Of<GameplayEvent>();
            MessageRelay.Register(new IMessageObserver(observer.Pointer), messageTypes);

            return observer;
        }
    }
}