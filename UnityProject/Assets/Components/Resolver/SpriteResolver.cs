using UnityEngine;
using UnityEngine.UI;
using TowerDominionUIMod.Generated;

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
        [SerializeField]
        public GameSprites sprite;
#else
        public Il2CppValueField<int> sprite;
#endif

        public void Start()
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            var gameSprite = GameAssets.Instance.GetGameSprite((GameSprites)sprite.Value);
            if (!gameSprite)
                return;
            
            // Get the Image component and assign the game asset to it
            var image = GetComponent<Image>();
            image.sprite = gameSprite;
            
            DestroyImmediate(this);
#endif
        }

#if !(UNITY_EDITOR || UNITY_STANDALONE)
        public SpriteResolver(IntPtr ptr) : base(ptr)
        {
        }
#endif
    }
}