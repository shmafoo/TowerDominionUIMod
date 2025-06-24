#if UNITY_EDITOR
using System.Linq;
using OpenCover.Framework.Model;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Build;
using UnityEngine;

internal static class BuildAddressablesMenu
{
    private const string SettingsPath = "Assets/AddressableAssetsData/AddressableAssetSettings.asset";
    private const string BuildScriptPath = "Assets/Editor/BuildScriptWithPrefix.asset";

    [MenuItem("Tools/Build Addressables")]
    public static void BuildAddressables()
    {
        // Load Addressables settings
        var settings = AssetDatabase.LoadAssetAtPath<AddressableAssetSettings>(SettingsPath);
        if (settings == null)
        {
            Debug.LogError($"❌ Addressable settings not found at '{SettingsPath}'.");
            return;
        }

        // Load build script
        var scriptObj = AssetDatabase.LoadAssetAtPath<ScriptableObject>(BuildScriptPath);
        if (scriptObj == null)
        {
            Debug.LogError($"❌ Build script not found at '{BuildScriptPath}'.");
            return;
        }

        if (scriptObj is IDataBuilder builder)
        {
            int index = settings.DataBuilders.IndexOf(scriptObj);
            if (index < 0)
            {
                Debug.LogError($"❌ The build script asset is not present in the 'Data Builders' list in Addressables Settings.");
                return;
            }

            settings.ActivePlayerDataBuilderIndex = index;
        }
        else
        {
            Debug.LogError($"❌ Loaded asset at '{BuildScriptPath}' does not implement IDataBuilder.");
            return;
        }

        // Build Addressables
        AddressableAssetSettings.BuildPlayerContent(out var result);
        if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.LogError("❌ Addressables build failed: " + result.Error);
        }
        else
        {
            Debug.Log("✅ Addressables build completed!");
        }
        
        var excludeBundlePath = result.AssetBundleBuildResults.FirstOrDefault(r => r.FilePath.Contains("exclude"));
        if (excludeBundlePath == null) return;
        
        Debug.Log($"Deleted excluded bundle: {FileUtil.DeleteFileOrDirectory(excludeBundlePath.FilePath)}");
    }
}
#endif