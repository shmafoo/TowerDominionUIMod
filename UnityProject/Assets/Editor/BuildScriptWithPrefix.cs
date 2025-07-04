using System;
using System.Linq;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Build.DataBuilders;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine;
using UnityEngine.Build.Pipeline;

[CreateAssetMenu(fileName = "BuildScriptWithPrefix.asset",
    menuName = "Addressables/Content Builders/Build Script with prefix")]
public class BuildScriptWithPrefix : BuildScriptPackedMode
{
    public override string Name => "Build Script with prefix";

    [SerializeField] public string Prefix = "";

    protected override string ConstructAssetBundleName(AddressableAssetGroup assetGroup, BundledAssetGroupSchema schema,
        BundleDetails info,
        string assetBundleName)
    {
        var baseString = base.ConstructAssetBundleName(assetGroup, schema, info, assetBundleName);
        return Prefix + baseString;
    }

    protected override TResult DoBuild<TResult>(AddressablesDataBuilderInput builderInput,
        AddressableAssetsBuildContext aaContext)
    {
        foreach (var group in aaContext.bundleToAssetGroup) Debug.Log($"{group.Key} -- {group.Value}");
        var result = base.DoBuild<TResult>(builderInput, aaContext);

        return result;
    }
}