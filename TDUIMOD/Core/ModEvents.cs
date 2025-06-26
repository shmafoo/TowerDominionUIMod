using System;

namespace TowerDominionUIMod.Core
{
    public static class ModEvents
    {
        public static event Action OnShowModOverlay;
        public static event Action OnHideModOverlay;

        public static void ShowModOverlay()
        {
            OnShowModOverlay?.Invoke();
        }

        public static void HideModOverlay()
        {
            OnHideModOverlay?.Invoke();
        }
    }
}