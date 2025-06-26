using System.Collections.Generic;
using Il2CppTMPro;
using MelonLoader;
using TowerDominionUIMod.Generated;
using UnityEngine;

namespace TowerDominionUIMod.Core
{
    public class GameAssets
    {
        private static readonly GameAssets instance = new();
        public static GameAssets Instance => instance;

        private static readonly Dictionary<string, Sprite> GameSprites = new();
        private static readonly Dictionary<string, TMP_FontAsset> GameFonts = new();

        public void Initialize()
        {
            GetAllGameSprites();
            GetAllGameFonts();
        }

        private void GetAllGameFonts()
        {
            var allFonts = Resources.FindObjectsOfTypeAll<TMP_FontAsset>();
            foreach (var font in allFonts)
                GameFonts[font.name] = font;
        }

        public TMP_FontAsset GetGameFont(string name)
        {
            if (!GameFonts.TryGetValue(name, out var font))
                MelonLogger.Error($"Could not find font with name {name} in game assets.");

            return font;
        }

        private void GetAllGameSprites()
        {
            if (GameSprites.Count > 0)
                return;

            var allSprites = Resources.FindObjectsOfTypeAll<Sprite>();

            foreach (var sprite in allSprites)
            {
                if (GameSprites.ContainsKey(sprite.name))
                    continue;

                GameSprites.Add(sprite.name, sprite);
            }
        }

        public Sprite GetGameSprite(GameSprites sprite)
        {
            return GetGameSprite(GetOriginalSpriteName(sprite));
        }

        public Sprite GetGameSprite(string name)
        {
            if (!GameSprites.TryGetValue(name, out var sprite))
                MelonLogger.Error($"Could not find sprite with name {name} in game assets.");

            return sprite;
        }

        public string GetOriginalSpriteName(GameSprites sprite)
        {
            return sprite.ToString().Replace("sprite_", "").Replace("_DOT", ".");
        }
    }
}