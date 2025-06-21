using MelonLoader;
using TowerDominionUIMod.Core;

namespace TowerDominionUIMod
{
    /// <summary>
    /// A MelonMod that adds UI modifications to Tower Dominion.
    /// </summary>
    public class UIMod : MelonMod
    {
        public override void OnInitializeMelon()
        {
            AssetBundles.Initialize();
        }

        /// <summary>
        /// Sets up view modification handlers when the Boot scene is loaded.
        /// </summary>
        /// <param name="buildIndex">The build index of the initialized scene</param>
        /// <param name="sceneName">The name of the initialized scene</param>
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "Boot")
            {
                ViewModRegistry.Initialize();
            }
        }
    }
}