using UnityEngine;
using UnityEngine.UI;

#if !(UNITY_EDITOR || UNITY_STANDALONE)
using MelonLoader;
using Il2Cpp;
using System;
#endif

namespace TowerDominionUIMod.Components.Resolver
{
#if (UNITY_EDITOR || UNITY_STANDALONE)
    [RequireComponent(typeof(Canvas))]
#else
    [RegisterTypeInIl2Cpp]
#endif
    public class UICameraResolver : MonoBehaviour
    {
        public void Awake()
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            // Get the camera used for the usual UI in the game
            var uiCamera = GameObject.Find("UICamera");
            if (!uiCamera)
            {
                MelonLogger.Error("Could not find UICamera.");
                return;
            }

            var canvas = GetComponent<Canvas>();
            canvas.worldCamera = uiCamera.GetComponent<Camera>();

            // Remove the dummy camera
            var dummy = transform.FindChildByName("DummyUICamera");
            if (!dummy)
            {
                MelonLogger.Error("Could not find DummyUICamera in ModHUD");
                return;
            }

            DestroyImmediate(dummy.gameObject);
            DestroyImmediate(this);
#endif
        }

#if !(UNITY_EDITOR || UNITY_STANDALONE)
        public UICameraResolver(IntPtr ptr) : base(ptr)
        {
        }
#endif
    }
}