using UnityEngine;

public abstract class WheelEffekt
{
    public string Description;
    public string Cost;
    public string Symbol;
    public EffektType type;
    public int color;
    public abstract void DoEffekt(Wheel contex);
    public abstract void doCost(Wheel contex);
}
