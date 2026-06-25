using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager:MonoBehaviour
{
    //false = Enemy turn
    //true = player turn
    public static bool currentWheel = true;
    public static int currentPhase = 1;
    public static int stage = 0;
    public static Color[] WheelColor = new Color[8]
    {
    new Color32(0xB6, 0x00, 0x7C, 255), // 0 Magenta/Pink
    new Color32(0xAB, 0x2C, 0x15, 255), // 1 Rotbraun
    new Color32(0x15, 0xAB, 0x31, 255), // 2 Grün
    new Color32(0x95, 0x00, 0xF2, 255), // 3 Violett
    new Color32(0xCE, 0x8D, 0x00, 255), // 4 Orange
    new Color32(0xCE, 0xCE, 0x00, 255), // 5 Gelb
    new Color32(0x00, 0x97, 0x95, 255), // 6 Türkis
    new Color32(0x00, 0x97, 0x95, 255)  // 7 Türkis (zweites Feld)
    };
    [Serializable]
    public struct MyDictionaryEntry
    {
        public string key;
        public Sprite sprite;
    }

    [SerializeField]
    private List<MyDictionaryEntry> localSprites;

    private void Start()
    {
        GameManager.instance = this;
        foreach (var entry in localSprites)
        {
               sprites.Add(entry.key, entry.sprite);
        }
    }
    public static GameManager instance;
    public static Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
    public static Wheel EnemyWheel;
    public static Wheel PlayerWheel;

    public static string Get(string type)
    {
        type =type.Trim();
        switch (type)
        {
            case "damage":
                return "<sprite name=\"sword\">";
                break;
            case "luck":
                return "<sprite name=\"luck\">";

                break;
            case "armor":
                return "<sprite name=\"armor\">";

                break;
            case "target":
                return "<sprite name=\"target\">";

                break;
            case "life":
                return "<sprite name=\"heart\">";

                break;
            case "poison":
                return "<sprite name=\"poison\">";
                break;
            case "vacine":
                return "<sprite name=\"vacine\">";
                break;
            case "weak":
                break;
            case "wheel":
                return "<sprite=3>";
                break;
            case "curse":
                return "<sprite name =\"curse\">";
            case "glass":
                return "<sprite name =\"glass\">";
        }
        return "<sprite name=\"broken\">";
    }
}
