using UnityEngine;

public abstract class WheelEffekt
{
    public string Description;
    public string Symbol;
    public EffektType type;
    public abstract void DoEffekt(Wheel contex);
}
