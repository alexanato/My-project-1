public abstract class WheelEffekt
{
    public string Description;
    public string name;
    public string Cost;
    public string Symbol;
    public EffektType type = EffektType.UTILITY;
    public int color;

    // Nur der Effekttyp bestimmt, ob ein Segment ein echter, nicht ersetzbarer Fluch ist.
    // Das verhindert, dass normale Synergieeffekte allein wegen ihres Symbols
    // versehentlich als Fluch behandelt werden.
    public bool IsCurse => type == EffektType.CURSE;

    // Echte Flüche zeigen immer das Fluchsymbol, selbst wenn eine einzelne
    // Effektklasse versehentlich ein anderes oder kein Symbol gesetzt hat.
    public string DisplaySymbol => IsCurse ? "curse" : Symbol;

    public virtual bool CanBeTriggeredAsSecondary => !IsCurse;

    public abstract void DoEffekt(Wheel contex);
    public abstract void doCost(Wheel contex);
    public abstract bool haveCost(Wheel contex);
}
