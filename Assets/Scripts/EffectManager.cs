using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private Dictionary<string, Type> effectRegistry = new Dictionary<string, Type>();

    void Awake()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in types)
        {
            if (type.IsAbstract) continue;

            var attribute = type.GetCustomAttribute<EffectAttribute>();

            if (attribute != null && type.IsSubclassOf(typeof(WheelEffekt)))
            {
                effectRegistry.Add(attribute.EffectId, type);
                Debug.Log($"[EffectRegistry] {attribute.EffectId} erfolgreich registriert!");
            }
        }
    }

    public WheelEffekt CreateEffect(string effectId)
    {
        if (effectRegistry.TryGetValue(effectId, out Type effectType))
        {
            return (WheelEffekt)Activator.CreateInstance(effectType);
        }

        Debug.LogError($"Effekt mit ID '{effectId}' wurde nicht gefunden!");
        return null;
    }
    public WheelEffekt CreateRandomEffect()
    {
        if (effectRegistry.Count == 0)
        {
            Debug.LogWarning("[EffectManager] Es sind keine Effekte registriert, die zufällig ausgewählt werden könnten!");
            return null;
        }

        var keys = effectRegistry.Keys.ToList();

        int randomIndex = UnityEngine.Random.Range(0, keys.Count);
        string randomEffectId = keys[randomIndex];

        return CreateEffect(randomEffectId);
    }
}