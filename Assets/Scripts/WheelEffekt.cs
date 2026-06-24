using UnityEngine;

public abstract class WheelEffekt
{
    public string Description;
    public string name;
    public string Cost;
    public string Symbol;
    public EffektType type = EffektType.DEFENSE;
    public int color;
    public abstract void DoEffekt(Wheel contex);
    public abstract void doCost(Wheel contex);
    public abstract bool haveCost(Wheel contex);
}
