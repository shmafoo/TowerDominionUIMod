using UnityEngine;
using UnityEngine.UI;

#if !(UNITY_EDITOR || UNITY_STANDALONE)
using System;
using Il2CppInterop.Runtime.InteropTypes.Fields;
using MelonLoader;
using TowerDominionUIMod.Core;
#endif

namespace TowerDominionUIMod.Components.Resolver
{
#if (UNITY_EDITOR || UNITY_STANDALONE)
        [RequireComponent(typeof(Image))]
#else
    [RegisterTypeInIl2Cpp]
#endif
    public class SpriteResolver : MonoBehaviour
    {
#if (UNITY_EDITOR || UNITY_STANDALONE)
                public string spriteName;
#else
        public Il2CppStringField spriteName;
#endif

        public void Awake()
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            // Look for a sprite with the name of spriteName in the games' assets
            var sprite = GameAssets.GetGameSprite(spriteName);
            if (!sprite)
            {
                MelonLogger.Error($"Could not find sprite with name {spriteName} in game assets.");
                return;
            }

            // Get the Image component and assign the game asset to it
            var image = GetComponent<Image>();
            image.sprite = sprite;
#endif
        }

#if !(UNITY_EDITOR || UNITY_STANDALONE)
        public SpriteResolver(IntPtr ptr) : base(ptr)
        {
        }
#endif
    }
}