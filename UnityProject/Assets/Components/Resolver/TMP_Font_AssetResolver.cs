using System.Collections.Generic;
using UnityEngine;

#if (UNITY_EDITOR || UNITY_STANDALONE)
using TMPro;
#else
using System;
using Il2CppInterop.Runtime.InteropTypes.Fields;
using Il2CppTMPro;
using MelonLoader;
using TowerDominionUIMod.Core;
#endif

namespace TowerDominionUIMod.Components.Resolver
{
#if (UNITY_EDITOR || UNITY_STANDALONE)
    [RequireComponent(typeof(TextMeshProUGUI))]
#else
    [RegisterTypeInIl2Cpp]
#endif
    public class TMP_Font_AssetResolver : MonoBehaviour
    {
        public enum GameFonts
        {
            ArchivoBlack = 0,
            bahnschrift,
            BebasNeue,
            LiberationSans,
            Roboto,
            TITLE,
            REGULAR,
            SPECIAL,
            NotoSansJP,
            NotoSansKR,
            NotoSansSC,
            NotoSansTC
        }

        private Dictionary<GameFonts, string> GameFontsMapping = new()
        {
            [GameFonts.ArchivoBlack] = "ArchivoBlack-Regular SDF",
            [GameFonts.bahnschrift] = "bahnschrift SDF",
            [GameFonts.BebasNeue] = "BebasNeue-Regular SDF",
            [GameFonts.LiberationSans] = "LiberationSans SDF",
            [GameFonts.Roboto] = "Roboto-Medium SDF - LanguageDropdown",
            [GameFonts.TITLE] = "TITLE",
            [GameFonts.REGULAR] = "REGULAR",
            [GameFonts.SPECIAL] = "SPECIAL",
            [GameFonts.NotoSansJP] = "NotoSansJP-Medium SDF - LanguageDropdown",
            [GameFonts.NotoSansKR] = "NotoSansKR-Medium SDF - LanguageDropdown",
            [GameFonts.NotoSansSC] = "NotoSansSC-Medium SDF - LanguageDropdown",
            [GameFonts.NotoSansTC] = "NotoSansTC-Medium SDF - LanguageDropdown"
        };

#if (UNITY_EDITOR || UNITY_STANDALONE)
        [SerializeField] public GameFonts font;
#else
        public Il2CppValueField<int> font;
#endif

        public void Start()
        {
#if !(UNITY_EDITOR || UNITY_STANDALONE)
            var fontName = GameFontsMapping[(GameFonts)font.Value];
            var fontAsset = GameAssets.Instance.GetGameFont(fontName);

            var tmpro = GetComponent<TextMeshProUGUI>();
            tmpro.font = fontAsset;
            tmpro.material = fontAsset.material;

            DestroyImmediate(this);
#endif
        }

#if !(UNITY_EDITOR || UNITY_STANDALONE)
        public TMP_Font_AssetResolver(IntPtr ptr) : base(ptr)
        {
        }
#endif
    }
}