#if (UNITY_EDITOR || UNITY_STANDALONE)
using Copper.ViewManager.Code.Interfaces;
using Nvizzio.Game.UI.Views;
using TMPro;
#else
using Il2CppCopper.ViewManager.Code.Interfaces;
using Il2CppNvizzio.Game.UI.Views;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Fields;
using MelonLoader;
#endif
using UnityEngine;

namespace TowerDominionUIMod.Components.Custom
{
    public class StatisticsView : BasicView
    {
#if (UNITY_EDITOR || UNITY_STANDALONE)
        [SerializeField]
        private RectTransform root;

        [SerializeField]
        private StyledButton closeButton;
#else
        public Il2CppReferenceField<RectTransform> root;
        public Il2CppReferenceField<StyledButton> closeButton;
#endif

        public override void Initialize(ViewActionComplete onInitializationComplete)
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            MelonLogger.Msg("StatisticsView.Initialize() called!");
            onInitializationComplete.Invoke();
#endif
        }

        public void CloseButtonClick()
        {
        }

        public void CloseView()
        {
        }
    }
}