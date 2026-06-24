using UnityEngine;
using UnityEditor;
using TMPro;

public class AssignSpriteAsset : EditorWindow
{
    public TMP_SpriteAsset spriteAsset;

    [MenuItem("Tools/Auto Assign Sprite Asset")]
    public static void ShowWindow() => GetWindow<AssignSpriteAsset>("Assign Sprite Asset");

    void OnGUI()
    {
        spriteAsset = (TMP_SpriteAsset)EditorGUILayout.ObjectField("Sprite Asset", spriteAsset, typeof(TMP_SpriteAsset), false);
        if (GUILayout.Button("Alle TMP in Szene zuweisen"))
        {
            foreach (var tmp in FindObjectsOfType<TextMeshProUGUI>())
            {
                tmp.spriteAsset = spriteAsset;
            }
            Debug.Log("Alle Texte wurden aktualisiert!");
        }
    }
}