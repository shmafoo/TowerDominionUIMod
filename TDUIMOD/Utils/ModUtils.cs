using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.Localization;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace TowerDominionUIMod.Utils
{
    public static class ModUtils
    {
        public static TDelegateType Il2CppDelegate<TDelegateType>(Il2CppSystem.Object target, string methodName,
            Il2CppSystem.Reflection.BindingFlags bindingAttr) where TDelegateType : Il2CppObjectBase
        {
            var targetMethod = target.GetIl2CppType().GetMethod(methodName, bindingAttr);

            var del = Il2CppSystem.Delegate.CreateDelegate(
                Il2CppType.Of<TDelegateType>(),
                target,
                targetMethod
            );

            return del.Cast<TDelegateType>();
        }

        public static List<T> ToSystemList<T>(
            this Il2CppSystem.Collections.Generic.IEnumerable<T> source)
        {
            var list = new List<T>();

            for (var i = 0; i < source.Count(); i++)
                list.Add(source.ElementAt(i));

            return list;
        }

        public static string GetBundlePath(this List<IResourceLocator> source,
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

        public static LocalizedString GetLocalizedString(string entryReference)
        {
            return new LocalizedString("TDUIMOD", entryReference);
        }
    }
}