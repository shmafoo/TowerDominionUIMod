using System.Collections.Generic;
using Il2CppNvizzio.Game.GamePlay.GameEntities;
using MelonLoader;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace TowerDominionUIMod.Core
{
    public static class FoeRegistry
    {
        private static readonly Dictionary<string, FoeData> Foes = new();

        static FoeRegistry()
        {
            Locale locale = null;

            foreach (var l in LocalizationSettings.AvailableLocales.Locales)
                if (l.Identifier.Code == "en")
                    locale = l;

            var foes = Resources.LoadAll<GameObject>("prefabs/entities/characters/foes");
            foreach (var foe in foes)
            {
                // this is most likely an incomplete prefab so we skip this
                if (!foe)
                    continue;

                var entity = foe.GetComponent<CharacterEntity>();
                var data = entity.CharacterData;

                try
                {
                    MelonLogger.Msg($"Foe: {foe.name}");
                    data.CharacterNameLocString.LocaleOverride = locale;
                    var loc = data.CharacterNameLocString.GetLocalizedString();
                    MelonLogger.Msg($" > Localized Name: {loc}");
                    MelonLogger.Msg($" > Base HP: {data.Health}");
                    MelonLogger.Msg($" > Base Shield: {data.Shield}");
                    MelonLogger.Msg($" > Base Speed: {data.Speed}");
                    MelonLogger.Msg($" > Is Air: {data.IsAircraft}");
                }
                catch
                {
                    continue;
                }

                MelonLogger.WriteLine(1);
            }
        }

        public static void Foo()
        {
        }

        public struct FoeData
        {
            public int health;
            public int shield;
            public int speed;
        }
    }
}