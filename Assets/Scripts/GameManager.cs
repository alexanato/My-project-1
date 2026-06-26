using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // false = Gegnerzug, Shop oder Kampf ist gesperrt
    // true = Spieler darf sein Rad im Kampf bedienen
    public static bool currentWheel = false;

    // 0 = Kampf, 1 = Shop, 2 = Lauf beendet
    public static int currentPhase = 0;
    public static int stage = 1;

    public static Color[] WheelColor = new Color[8]
    {
        new Color32(0xB6, 0x00, 0x7C, 255),
        new Color32(0xAB, 0x2C, 0x15, 255),
        new Color32(0x15, 0xAB, 0x31, 255),
        new Color32(0x95, 0x00, 0xF2, 255),
        new Color32(0xCE, 0x8D, 0x00, 255),
        new Color32(0xCE, 0xCE, 0x00, 255),
        new Color32(0x00, 0x97, 0x95, 255),
        new Color32(0x00, 0x97, 0x95, 255)
    };

    [Serializable]
    public struct MyDictionaryEntry
    {
        public string key;
        public Sprite sprite;
    }

    [SerializeField] private List<MyDictionaryEntry> localSprites = new List<MyDictionaryEntry>();

    public static GameManager instance;
    public static Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
    public static Wheel EnemyWheel;
    public static Wheel PlayerWheel;

    // Wird auch ausgeführt, wenn im Unity-Editor "Enter Play Mode Options"
    // ohne Domain Reload verwendet wird. So bleiben keine Werte aus dem
    // vorherigen Testlauf erhalten.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetStaticsBeforePlayMode()
    {
        ResetStaticFields();
    }

    private void Awake()
    {
        // Jede neu geladene Gameplay-Scene beginnt einen vollständig neuen Run.
        ResetRunState();
        instance = this;
        RegisterSprites();
    }

    /// <summary>
    /// Setzt alle Daten zurück, die einen Scene-Wechsel überleben können.
    /// Player- und Enemy-Instanzwerte werden anschließend in deren Start()-
    /// Methoden neu initialisiert.
    /// </summary>
    public static void ResetRunState()
    {
        ResetStaticFields();

        // Verhindert, dass ein pausierter Run nach dem Reload pausiert bleibt.
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    private static void ResetStaticFields()
    {
        currentWheel = false;
        currentPhase = 0;
        stage = 1;

        EnemyWheel = null;
        PlayerWheel = null;
        instance = null;

        if (sprites == null)
        {
            sprites = new Dictionary<string, Sprite>();
        }
        else
        {
            sprites.Clear();
        }
    }

    private void RegisterSprites()
    {
        if (localSprites == null)
        {
            return;
        }

        foreach (MyDictionaryEntry entry in localSprites)
        {
            if (string.IsNullOrWhiteSpace(entry.key) || entry.sprite == null)
            {
                continue;
            }

            // Doppelte Inspector-Einträge überschreiben den alten Wert,
            // statt beim Start eine Exception auszulösen.
            sprites[entry.key.Trim()] = entry.sprite;
        }
    }

    public static void ConnectWheels()
    {
        if (PlayerWheel == null || EnemyWheel == null)
        {
            return;
        }

        PlayerWheel.EnemyWheel = EnemyWheel;
        EnemyWheel.EnemyWheel = PlayerWheel;
    }

    public static string Get(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            return string.Empty;
        }

        switch (type.Trim())
        {
            case "damage": return "<sprite name=\"sword\">";
            case "luck": return "<sprite name=\"luck\">";
            case "armor": return "<sprite name=\"armor\">";
            case "target": return "<sprite name=\"target\">";
            case "life": return "<sprite name=\"heart\">";
            case "poison": return "<sprite name=\"poison\">";
            case "vacine": return "<sprite name=\"vacine\">";
            case "weak": return "<sprite name=\"broken\">";
            case "wheel": return "<sprite=3>";
            case "curse": return "<sprite name=\"curse\">";
            case "glass": return "<sprite name=\"glass\">";
            default: return "<sprite name=\"broken\">";
        }
    }
}
