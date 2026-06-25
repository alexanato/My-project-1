using UnityEngine;

[Effect("SlowMotion")]
public class SlowMotion : WheelEffekt
{
    // Original Rad-Effekt: -3 WheelSpeed (Rad verlangsamt sich massiv), +1 Wheel.
    // Original Kauf-Modifikator: -2 Basis-Wheel.
    public SlowMotion()
    {
        name = "Slow Motion";
        Symbol = "bell";
        Description = "-1 speed";
        Cost = "+3 speed";
    }

    public override void doCost(Wheel contex)
    {
        contex.rotRange.y += 3;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.rotRange.y -= 1;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}