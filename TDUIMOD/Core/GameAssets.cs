using System.Collections.Generic;
using MelonLoader;
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

    public Sprite GetGameSprite(string name)
    {
        MelonLogger.Msg($"Trying to get game sprite with name {name}");
        MelonLogger.Msg($"Dictionary size: {GameSprites.Count}");

        var result = GameSprites.TryGetValue(name, out var sprite);
        MelonLogger.Msg($"Found: {result}");
        MelonLogger.Msg($"Sprite: {sprite.name}");

        return sprite;
    }
}