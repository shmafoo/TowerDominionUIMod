using Il2CppNvizzio.Game.UI.Views;
using TowerDominionUIMod.Core;

namespace TowerDominionUIMod.Core
{
    public abstract class ModifiedViewBase : IModifyView
    {
        public bool IsModified { get; set; }
        public bool AlwaysModify { get; set; }

        public void ModifyView()
        {
            if (IsModified && !AlwaysModify)
                return;

            OnModify();
            IsModified = true;
        }

        protected abstract void OnModify();
    }
}