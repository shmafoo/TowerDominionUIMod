using TowerDominionUIMod.Core;

namespace TowerDominionUIMod.ViewMods;

[ViewName("PersistentGameHUDView")]
public class PersistentGameHUDViewMod : ModifiedViewBase
{
    public override void ViewOpened()
    {
        ModEvents.ShowModOverlay();
    }

    public override void ViewClosed()
    {
        ModEvents.HideModOverlay();
    }
}