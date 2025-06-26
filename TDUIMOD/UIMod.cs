using Il2Cpp;
using Il2CppCopper.ViewManager.Code.Interfaces;
using Il2CppInterop.Runtime.Injection;
using Il2CppNvizzio.Core.Messaging;
using MelonLoader;
using TowerDominionUIMod.Components.Custom;
using TowerDominionUIMod.Core;

namespace TowerDominionUIMod
{
    /// <summary>
    ///     A MelonMod that adds UI modifications to Tower Dominion.
    /// </summary>
    public class UIMod : MelonMod
    {
        public override void OnInitializeMelon()
        {
            // ClassInjector.RegisterTypeInIl2Cpp<StatisticsView>(new RegisterTypeOptions()
            // {
            //     Interfaces = new[] {typeof(IGameEventListener)},
            // });

            AssetBundles.Instance.Initialize();
        }

        public override void OnApplicationQuit()
        {
            ModOverlay.Instance.Cleanup();
        }

        /// <summary>
        ///     Sets up view modification handlers when the Boot scene is loaded.
        /// </summary>
        /// <param name="buildIndex">The build index of the initialized scene</param>
        /// <param name="sceneName">The name of the initialized scene</param>
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            switch (sceneName)
            {
                case "Boot":
                    OnBootSceneInitialized();
                    break;
                case "GameplayScene":
                    OnGameplaySceneInitialized();
                    break;
            }
        }

        private void OnGameplaySceneInitialized()
        {
            GameAssets.Instance.Initialize();
            ModOverlay.Instance.Initialize();
        }

        private void OnBootSceneInitialized()
        {
            ViewModRegistry.Initialize();
        }
    }
}