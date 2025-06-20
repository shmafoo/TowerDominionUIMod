using System.Collections;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Reflection;
using MelonLoader;
using UnityEngine.Localization;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TowerDominionUIMod.Utils
{
    public static class ModUtils
    {
        public static TDelegateType Il2CppDelegate<TDelegateType>(Il2CppSystem.Object target, string methodName, BindingFlags bindingAttr) where TDelegateType : Il2CppObjectBase
        {
            var targetMethod = target.GetIl2CppType().
                GetMethod(methodName, bindingAttr);
            
            var del = Il2CppSystem.Delegate.CreateDelegate(
                Il2CppType.Of<TDelegateType>(),
                target,
                targetMethod
            );

            return del.Cast<TDelegateType>();
        }
    }
}