using Il2CppCopper.ViewManager.Code;
using MelonLoader;
using TowerDominionUIMod.Core;
using TowerDominionUIMod.ViewMods;

namespace TowerDominionUIMod
{
    /// <summary>
    /// A MelonMod that adds UI modifications to Tower Dominion.
    /// </summary>
    public class UIMod : MelonMod
    {
        /// <summary>
        /// Sets up view modification handlers when the Boot scene is loaded.
        /// </summary>
        /// <param name="buildIndex">The build index of the initialized scene</param>
        /// <param name="sceneName">The name of the initialized scene</param>
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "Boot")
            {
                ViewManager.Instance.onViewOpened += (ViewManager.ViewChangedMethod)((int Id) =>
                {
                    if (!ViewModRegistry.TryGetNameFromId(Id, out var viewName))
                        return;
                    
                    if (viewName != null && ViewModRegistry.TryGetModifier(viewName, out var modifier))
                        modifier.ModifyView();
                });
            }
        }
    }
}