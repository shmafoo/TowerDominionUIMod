using System.Linq;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using Il2CppSystem.Linq;
using MelonLoader;
using UnityEngine;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using Object = Il2CppSystem.Object;

namespace TowerDominionUIMod.Utils;

public static class ModUtils
{
    public static TDelegateType Il2CppDelegate<TDelegateType>(Object target, string methodName,
        Il2CppSystem.Reflection.BindingFlags bindingAttr) where TDelegateType : Il2CppObjectBase
    {
        var targetMethod = target.GetIl2CppType().GetMethod(methodName, bindingAttr);

        var del = Delegate.CreateDelegate(
            Il2CppType.Of<TDelegateType>(),
            target,
            targetMethod
        );

        return del.Cast<TDelegateType>();
    }

    public static System.Collections.Generic.List<T> ToSystemList<T>(
        this Il2CppSystem.Collections.Generic.IEnumerable<T> source)
    {
        var list = new System.Collections.Generic.List<T>();

        for (var i = 0; i < source.Count(); i++)
            list.Add(source.ElementAt(i));

        return list;
    }

    public static string GetBundlePath(this System.Collections.Generic.List<IResourceLocator> source,
        string assetAddress)
    {
        string bundlePath = null;

        source.FirstOrDefault((locator) =>
        {
            locator.Locate(assetAddress, Il2CppType.Of<GameObject>(), out var result);
            if (result?[0].PrimaryKey != assetAddress) return false;

            var dependencies = result?[0].Dependencies.Cast<Il2CppSystem.Collections.IEnumerable>().GetEnumerator();
            dependencies?.MoveNext();

            var resource = dependencies?.Current.Cast<IResourceLocation>();
            if (resource == null) return false;

            bundlePath = resource.InternalId;
            return true;
        });

        return bundlePath;
    }
}