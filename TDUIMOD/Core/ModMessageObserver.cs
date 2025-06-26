using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppNvizzio.Core.Messaging;
using MelonLoader;
using UnityEngine.Events;

namespace TowerDominionUIMod.Core
{
    [RegisterTypeInIl2CppWithInterfaces(typeof(IMessageObserver))]
    public class ModMessageObserver : Il2CppSystem.Object
    {
        public delegate void MessageCallback(Il2CppSystem.IComparable message, Il2CppReferenceArray<Il2CppSystem.Object> data);
        public MessageCallback Callback;
        
        public ModMessageObserver(IntPtr ptr) : base(ptr) { }
        public ModMessageObserver() : base(ClassInjector.DerivedConstructorPointer<ModMessageObserver>()) => ClassInjector.DerivedConstructorBody(this);

        public void SetCallback(MessageCallback callback)
        {
            Callback = callback;
        }
        
        public void HandleMessage(Il2CppSystem.IComparable message, Il2CppReferenceArray<Il2CppSystem.Object> data)
        {
            Callback?.Invoke(message, data);
        }
    }
}