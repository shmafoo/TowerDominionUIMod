using UnityEngine;

public class ViewInfo : ScriptableObject
{
    public string viewID;
    public int layerID;
    public string view;
    public bool isDialog;
    public bool persistent;
    public bool unloadUnusedAssetsOnDestroy;
    public string loadType;
    public int ViewID;
    public string ViewIDName;
    public int LayerID;
    public string ViewPath;
    public bool IsDialog;
    public bool Persistent;
    public bool UnloadUnusedAssetsOnDestroy;
    public string LoadType;
    public bool HasName;
    public string Name;

    public static int Compare(ViewInfo a, ViewInfo b)
    {
        return 0;
    }
}