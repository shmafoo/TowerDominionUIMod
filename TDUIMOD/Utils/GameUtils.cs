using Il2CppTMPro;
using MelonLoader;
using UnityEngine;
using UnityEngine.Localization;

namespace TowerDominionUIMod.Utils;

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

        var buttonInstance = Object.Instantiate(buttonPrefab, parent);
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
}