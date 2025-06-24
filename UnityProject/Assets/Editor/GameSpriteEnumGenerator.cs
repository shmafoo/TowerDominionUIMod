// Place this in Assets/Editor/EnumGenerator.cs
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public static class GameSpriteEnumGenerator
{
    private const string EnumNamespace = "TowerDominionUIMod.Generated";
    private const string EnumFilePath = "Assets/Generated/GameSprites.cs";
    private const string EnumName = "GameSprites";
    private const string SpriteFolder = "Assets/Sprite";

    [MenuItem("Tools/Generate/GameSprites Enum")]
    public static void GenerateGameSpritesEnum()
    {
        // Find all sprite assets in the folder
        string[] guids = AssetDatabase.FindAssets("t:Sprite", new[] {SpriteFolder});
        List<string> names = guids
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(Path.GetFileNameWithoutExtension)
            .Distinct()
            .OrderBy(n => n)
            .ToList();

        // Generate (and preserve existing enum values if needed)
        WriteEnumFile(EnumFilePath, EnumName, names);
        AssetDatabase.Refresh();
        Debug.Log($"Generated {names.Count} entries in {EnumFilePath}");
    }

    private static void WriteEnumFile(string path, string enumName, List<string> values)
    {
        using (var writer = new StreamWriter(path))
        {
            writer.WriteLine("// This file is auto-generated. Do not edit.");
            writer.WriteLine($"namespace {EnumNamespace} {{");
            writer.WriteLine($"    public enum {enumName}");
            writer.WriteLine("    {");

            foreach (string name in values)
            {
                writer.WriteLine($"        {SanitizeName(name)},");
            }

            writer.WriteLine("    }");
            
            writer.WriteLine();
            writer.WriteLine("    public static class GameSpritesExtensions");
            writer.WriteLine("    {");
            writer.WriteLine("        public static string Get(this GameSprites gs) => gs.ToString().Replace(\"sprite_\", \"\").Replace(\"_DOT_\", \".\");");
            writer.WriteLine("    }");
            
            writer.WriteLine("}");
        }
    }
    
    private static string SanitizeName(string name)
    {
        return $"sprite_{name.Replace(".", "_DOT_")}";
    }
}
