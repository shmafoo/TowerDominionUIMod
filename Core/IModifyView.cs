namespace TowerDominionUIMod.Core
{
    public interface IModifyView
    {
        bool IsModified { get; set; }
        bool AlwaysModify { get; set; }
        
        void ModifyView();
    }
}