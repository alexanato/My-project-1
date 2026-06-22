using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager:MonoBehaviour
{
    //false = Enemy turn
    //true = player turn
    public static bool currentWheel = true;
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
        switch (type)
        {
            case "damage":
                return "<sprite name=\"sword\">";
                break;
            case "luck":
                return "<sprite name=\"bell\">";

                break;
            case "armor":
                return "<sprite name=\"armor\">";

                break;
            case "target":
                return "<sprite name=\"target\">";

                break;
            case "life":
                return "<sprite name=\"life\">";

                break;
            case "poison":
                return "<sprite name=\"poison\">";

                break;
        }
        return "<sprite name=\"broken\">";
    }
}
