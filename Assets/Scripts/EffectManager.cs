using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private readonly Dictionary<string, Type> effectRegistry = new Dictionary<string, Type>();

    private void Awake()
    {
        effectRegistry.Clear();

        Type[] types;
        try
        {
            types = Assembly.GetExecutingAssembly().GetTypes();
        }
        catch (ReflectionTypeLoadException exception)
        {
            types = exception.Types.Where(type => type != null).ToArray();
            Debug.LogWarning("Einige Typen konnten nicht geladen werden. Registrierbare Effekte werden trotzdem verwendet.");
        }

        foreach (Type type in types)
        {
            if (type == null || type.IsAbstract || !type.IsSubclassOf(typeof(WheelEffekt)))
            {
                continue;
            }

            EffectAttribute attribute = type.GetCustomAttribute<EffectAttribute>(false);
            if (attribute == null || string.IsNullOrWhiteSpace(attribute.EffectId))
            {
                continue;
            }

            if (type.GetConstructor(Type.EmptyTypes) == null)
            {
                Debug.LogError("Effekt '" + type.Name + "' benötigt einen öffentlichen parameterlosen Konstruktor.");
                continue;
            }

            string effectId = attribute.EffectId.Trim();
            if (effectRegistry.ContainsKey(effectId))
            {
                Debug.LogError("Doppelte Effekt-ID: " + effectId);
                continue;
            }

            effectRegistry.Add(effectId, type);
        }
    }

    public WheelEffekt CreateEffect(string effectId)
    {
        if (string.IsNullOrWhiteSpace(effectId))
        {
            return null;
        }

        Type effectType;
        if (!effectRegistry.TryGetValue(effectId.Trim(), out effectType))
        {
            Debug.LogError("Effekt mit ID '" + effectId + "' wurde nicht gefunden.");
            return null;
        }

        try
        {
            return Activator.CreateInstance(effectType) as WheelEffekt;
        }
        catch (Exception exception)
        {
            Debug.LogError("Effekt '" + effectId + "' konnte nicht erstellt werden: " + exception.Message);
            return null;
        }
    }

    public WheelEffekt CreateRandomEffect()
    {
        if (effectRegistry.Count == 0)
        {
            Debug.LogWarning("Es sind keine Shop-Effekte registriert.");
            return null;
        }

        List<string> keys = effectRegistry.Keys.ToList();
        int randomIndex = UnityEngine.Random.Range(0, keys.Count);
        return CreateEffect(keys[randomIndex]);
    }
}
