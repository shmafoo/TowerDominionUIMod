using System.Collections.Generic;
using MelonLoader;
using TowerDominionUIMod.Generated;
using UnityEngine;

namespace TowerDominionUIMod.Core;

public class GameAssets
{
    private static readonly GameAssets instance = new();
    public static GameAssets Instance => instance;

    private static readonly Dictionary<string, Sprite> GameSprites = new();

    public void Initialize()
    {
        GetAllGameSprites();
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
        {
            MelonLogger.Error($"Could not find sprite with name {name} in game assets.");
        }

        return sprite;
    }

    public string GetOriginalSpriteName(GameSprites sprite)
    {
        return sprite.ToString().Replace("sprite_", "").Replace("_DOT", ".");
    }
}