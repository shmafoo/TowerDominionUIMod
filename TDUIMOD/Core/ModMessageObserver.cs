using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppNvizzio.Core.Messaging;
using Il2CppNvizzio.Game.GamePlay.Events;
using MelonLoader;
using UnityEngine.Events;

namespace TowerDominionUIMod.Core
{
    [RegisterTypeInIl2CppWithInterfaces(typeof(IMessageObserver))]
    public class ModMessageObserver : Il2CppSystem.Object
    {
        public delegate void MessageCallback(Il2CppSystem.IComparable message,
            Il2CppReferenceArray<Il2CppSystem.Object> data);

        public MessageCallback Callback;
        public List<GameplayEvent> observedGameplayEvents;

        public ModMessageObserver(IntPtr ptr) : base(ptr)
        {
        }

        public ModMessageObserver(MessageCallback cb, List<GameplayEvent> observedEvents = null) : base(ClassInjector.DerivedConstructorPointer<ModMessageObserver>())
        {
            Callback = cb;
            observedGameplayEvents = observedEvents ?? new();
            
            ClassInjector.DerivedConstructorBody(this);
        }

        public void HandleMessage(Il2CppSystem.IComparable message, Il2CppReferenceArray<Il2CppSystem.Object> data)
        {
            var messageType = message.Unbox<GameplayEvent>();

            if (observedGameplayEvents.Count > 0 && !observedGameplayEvents.Contains(messageType))
                return;
            
            Callback?.Invoke(message, data);
        }
    }
}