using System.Collections.Generic;
using UnityEngine;

namespace TowerDominionUIMod.Core;

public static class GameAssets
{
    private static readonly Dictionary<string, Sprite> GameSprites = new();

    static GameAssets()
    {
        GetAllGameSprites();
    }

    private static void GetAllGameSprites()
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

    public static Sprite GetGameSprite(string name)
    {
        var result = GameSprites.TryGetValue(name, out var sprite);
        return sprite;
    }
}