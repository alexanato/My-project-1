public abstract class WheelEffekt
{
    public string Description;
    public string name;
    public string Cost;
    public string Symbol;
    public EffektType type = EffektType.UTILITY;
    public int color;

    public bool IsCurse => type == EffektType.CURSE || Symbol == "curse";
    public virtual bool CanBeTriggeredAsSecondary => !IsCurse;

    public abstract void DoEffekt(Wheel contex);
    public abstract void doCost(Wheel contex);
    public abstract bool haveCost(Wheel contex);
}
