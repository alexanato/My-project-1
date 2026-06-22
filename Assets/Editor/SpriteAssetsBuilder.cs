using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore;

public class SpriteAssetBuilder : EditorWindow
{
    [MenuItem("Tools/Create Combined Sprite Asset")]
    public static void CreateAsset()
    {
        // 1. Alle markierten Objekte holen
        Object[] selectedObjects = Selection.objects;
        List<Texture2D> textures = new List<Texture2D>();

        foreach (Object obj in selectedObjects)
        {
            if (obj is Texture2D tex)
            {
                // Sicherstellen, dass die Textur lesbar ist
                MakeTextureReadable(tex);
                textures.Add(tex);
            }
        }

        if (textures.Count == 0)
        {
            EditorUtility.DisplayDialog("Fehler", "Bitte markiere zuerst deine Icon-Bilder im Project-Fenster!", "Ok");
            return;
        }

        // 2. Ein neues, leeres Kombi-Bild (Atlas) erstellen
        Texture2D atlas = new Texture2D(2048, 2048, TextureFormat.RGBA32, false);

        // Unity packt alle Einzelbilder automatisch auf das neue Kombi-Bild
        // Rects[] speichert danach exakt, wo welches Bild gelandet ist (0.0 bis 1.0)
        Rect[] rects = atlas.PackTextures(textures.ToArray(), 2, 2048);

        // 3. Das neu generierte Kombi-Bild im Assets-Ordner speichern
        byte[] atlasPng = atlas.EncodeToPNG();
        string atlasPath = "Assets/Kombiniertes_Sprite_Bild.png";
        File.WriteAllBytes(atlasPath, atlasPng);
        AssetDatabase.ImportAsset(atlasPath);

        // Das gespeicherte Bild als Sprite konfigurieren
        TextureImporter importer = AssetImporter.GetAtPath(atlasPath) as TextureImporter;
        if (importer != null)
        {
            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Multiple;
            importer.SaveAndReimport();
        }

        // Das frisch importierte Sprite-Objekt wieder laden
        Texture2D savedAtlasTex = AssetDatabase.LoadAssetAtPath<Texture2D>(atlasPath);

        // 4. Das finale TextMeshPro Sprite Asset erstellen
        TMP_SpriteAsset spriteAsset = ScriptableObject.CreateInstance<TMP_SpriteAsset>();
        spriteAsset.spriteSheet = savedAtlasTex;
        spriteAsset.spriteCharacterTable.Clear();
        spriteAsset.spriteGlyphTable.Clear();

        // 5. Die Positionsdaten für jedes Icon berechnen und eintragen
        for (int i = 0; i < textures.Count; i++)
        {
            Rect r = rects[i];
            // Umrechnung von Prozent (0-1) in echte Pixelkoordinaten
            int x = Mathf.RoundToInt(r.x * atlas.width);
            int y = Mathf.RoundToInt(r.y * atlas.height);
            int w = Mathf.RoundToInt(r.width * atlas.width);
            int h = Mathf.RoundToInt(r.height * atlas.height);

            TMP_SpriteGlyph glyph = new TMP_SpriteGlyph();
            glyph.index = (uint)i;
            glyph.metrics = new GlyphMetrics(w, h, 0, h, w);
            glyph.glyphRect = new GlyphRect(x, y, w, h);
            glyph.scale = 1;
            spriteAsset.spriteGlyphTable.Add(glyph);

            TMP_SpriteCharacter character = new TMP_SpriteCharacter((uint)i, glyph);
            character.name = textures[i].name; // Behält den Namen deiner Originaldatei
            character.scale = 1;
            spriteAsset.spriteCharacterTable.Add(character);
        }

        // 6. Das fertige Sprite Asset speichern
        string assetPath = "Assets/Kombiniertes_Sprite_Asset.asset";
        AssetDatabase.CreateAsset(spriteAsset, assetPath);

        TMPro_EventManager.ON_SPRITE_ASSET_PROPERTY_CHANGED(true, spriteAsset);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        EditorUtility.DisplayDialog("Erfolg!", "Es wurden zwei Dateien unter 'Assets/' erstellt:\n1. Ein kombiniertes PNG-Bild\n2. Das fertige Sprite Asset!", "Super!");
    }

    // Hilfsfunktion: Schaltet temporär "Read/Write" im Bild ein, falls es deaktiviert war
    private static void MakeTextureReadable(Texture2D tex)
    {
        string path = AssetDatabase.GetAssetPath(tex);
        TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;
        if (importer != null && !importer.isReadable)
        {
            importer.isReadable = true;
            importer.SaveAndReimport();
        }
    }
}