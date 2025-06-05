using System;
using Il2CppNvizzio.Game.UI.Views;
using MelonLoader;
using UnityEngine;
using Object = UnityEngine.Object;
using Il2Cpp;
using Il2CppTMPro;
using TowerDominionUIMod.Core;

/// <summary>
/// Modifies the CharacterSelectionView by adding a SelectAll button functionality
/// to improve user experience in the Expert Mode view.
/// </summary>
/// <remarks>
/// This modifier:
/// <list type="bullet">
/// <item><description>Adds a SelectAll button to the Character Selection screen</description></item>
/// <item><description>Manages button visibility based on Expert Mode state</description></item>
/// <item><description>Handles mass selection of modifiers when the button is clicked</description></item>
/// </list>
/// </remarks>
namespace TowerDominionUIMod.ViewMods
{
    [ViewName("CharacterSelectionView")]
    public class CharacterSelectionViewMod : ModifiedViewBase
    {
        private CharacterSelectionView CharacterSelection = null;
        private GameObject SelectAllButton = null;
        private Action SelectAllButtonClicked = null;

        /// <summary>
        /// Initializes the SelectAll button and sets up its UI components and event handlers.
        /// </summary>
        protected override void OnModify()
        {
            AlwaysModify = true;
            MelonLogger.Msg("Modifying CharacterSelectionView");

            CharacterSelection = Object.FindFirstObjectByType<CharacterSelectionView>();
            if (!CharacterSelection)
            {
                MelonLogger.Error("Could not find CharacterSelectionView");
                return;
            }

            var buttonAsset = Resources.Load<GameObject>("prefabs/ui/BaseButton");
            if (!buttonAsset)
            {
                MelonLogger.Error("Button Prefab not found");
                return;
            }

            var footer = CharacterSelection.transform.FindChildByName("Footer");
            if (!footer)
            {
                MelonLogger.Error("Could not find footer in CharacterSelectionView");
                return;
            }

            var startButton = footer.transform.FindChildByName("StartButton");
            if (!startButton)
            {
                MelonLogger.Error("Could not find startButton in CharacterSelectionView");
                return;
            }
            
            SelectAllButton = Object.Instantiate(buttonAsset, footer);
            SelectAllButton.active = false;
            SelectAllButton.name = "SelectAllButton";
            SelectAllButton.transform.position = new Vector3(5.5f, startButton.transform.position.y, 0.0f);
            
            var selectAllButtonTextComponent = SelectAllButton.transform.GetComponentInChildren<TextMeshProUGUI>();
            if (!selectAllButtonTextComponent)
            {
                MelonLogger.Error("Could not find text on selectAllButton");
                return;
            }
            selectAllButtonTextComponent.text = "Select All";

            var selectAllStyledButton = SelectAllButton.GetComponent<StyledButton>();
            SelectAllButtonClicked += OnSelectAllButtonClicked;
            selectAllStyledButton.onClick.AddListener(SelectAllButtonClicked);
        }

        /// <summary>
        /// Handles the SelectAll button click event by selecting all modifiers in the ExpertModeView.
        /// </summary>
        public void OnSelectAllButtonClicked()
        {
            if (!CharacterSelection)
            {
                MelonLogger.Error("CharacterSelectionView not selected");
                return;
            }

            var expertMode = CharacterSelection.transform.FindChildByName("ExpertMode");
            if (!expertMode)
            {
                MelonLogger.Error("Could not find expert mode in CharacterSelectionView");
                return;
            }
            
            var body = expertMode.transform.FindChildByName("Body");
            for (int i = 0; i < body.childCount; i++)
            {
                var toggle = body.GetChild(i).GetComponent<StyledToggle>();
                toggle.isOn = true;
                // toggle.OnSelect(null);
            }
        }
        
        /// <summary>
        /// Shows the SelectAll button when entering ExpertModeView.
        /// </summary>
        public void ExpertModeViewEntered()
        {   
            if (!CharacterSelection)
            {
                MelonLogger.Error("Could not find CharacterSelectionView");
                return;
            }
            
            SelectAllButton.active = true;
        }
        
        /// <summary>
        /// Hides the SelectAll button when exiting ExpertModeView.
        /// </summary>
        public void ExpertModeViewClosed()
        {
            if (!CharacterSelection)
            {
                MelonLogger.Error("Could not find CharacterSelectionView");
                return;
            }
            
            SelectAllButton.active = false;
        }
    }
}