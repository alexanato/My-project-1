using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class)]
public class EffectAttribute : Attribute
{
    public string EffectId { get; }
    public EffectAttribute(string effectId) => EffectId = effectId;
}