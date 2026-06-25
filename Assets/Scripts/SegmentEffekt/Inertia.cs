using UnityEngine;

[Effect("Inertia")]
public class Inertia : WheelEffekt
{
    // Original Rad-Effekt: -2 WheelSpeed für die nächste Runde, -3 Damage.
    // Original Kauf-Modifikator: +1 Basis-Wheel.
    public Inertia()
    {
        name = "Inertia";
        Symbol = "bell";
        Description = "+1 speed";
    }

    public override void doCost(Wheel contex)
    {
        contex.baseWheelCount += 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.rotRange.y += 1;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}