using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using Il2CppSystem.Reflection;

namespace TowerDominionUIMod.Utils;

public static class ModUtils
{
    public static TDelegateType Il2CppDelegate<TDelegateType>(Object target, string methodName,
        BindingFlags bindingAttr) where TDelegateType : Il2CppObjectBase
    {
        var targetMethod = target.GetIl2CppType().GetMethod(methodName, bindingAttr);

        var del = Delegate.CreateDelegate(
            Il2CppType.Of<TDelegateType>(),
            target,
            targetMethod
        );

        return del.Cast<TDelegateType>();
    }
}