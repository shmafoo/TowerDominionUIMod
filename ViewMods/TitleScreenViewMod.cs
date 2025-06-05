using Il2Cpp;
using Il2CppNvizzio.Game.UI.Views;
using Il2CppTMPro;
using MelonLoader;
using Object = UnityEngine.Object;
using TowerDominionUIMod.Core;

/// <summary>
/// Modifies the title screen view by customizing UI elements.
/// This modifier demonstrates basic UI customization capabilities
/// by modifying text elements in the main menu.
/// </summary>
namespace TowerDominionUIMod.ViewMods
{
    [ViewName("TitleView")]
    public class TitleScreenViewMod : ModifiedViewBase
    {
        /// <summary>
        /// Customizes the quit button text in the title screen as a test.
        /// </summary>
        /// <remarks>
        /// This method:
        /// <list type="bullet">
        /// <item><description>Locates the quit button in the UI hierarchy</description></item>
        /// <item><description>Modifies its text to display "Bye" instead of the default text</description></item>
        /// <item><description>Logs any errors encountered during the modification process</description></item>
        /// </list>
        /// </remarks>
        protected override void OnModify()
        {
            MelonLogger.Msg($"Modifying TitleScreenView");

            var mainMenu = Object.FindFirstObjectByType<TitleScreenView>();
            if (!mainMenu)
            {
                MelonLogger.Error("Could not find TitleScreenView");
                return;
            }

            var content = mainMenu.transform.FindChildByName("Content");
            if (!content)
                MelonLogger.Error("Could not find content canvas");
            
            var buttons = content.FindChildByName("Buttons");
            if (!buttons)
                MelonLogger.Error("Could not find buttons");
            
            var quitButton = buttons.transform.FindChildByName("Quit");
            if (!quitButton)
                MelonLogger.Error("Could not find quitButton");
            
            var quitButtonText = quitButton.FindChildByName("Text");
            if (!quitButtonText)
                MelonLogger.Error("Could not find quitButtonText");
            
            var quitButtonTextComponent = quitButtonText.GetComponent<TextMeshProUGUI>();
            if (!quitButtonTextComponent)
                MelonLogger.Error("Could not find quitButtonTextComponent");
            else
                quitButtonTextComponent.text = "Bye";
        }
    }
}