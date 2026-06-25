using UnityEngine;

[Effect("CurseLeadWeight")]
public class CurseLeadWeight : WheelEffekt
{
    // Original Rad-Effekt: Fluch: Bleigewicht Dein WheelSpeed erhöht sich für den Rest des Kampfes um +5.
    // Original Kauf-Modifikator: +2 Basis-Wheel.
    public CurseLeadWeight()
    {
        name = "Lead Weight";
        Symbol = "curse";
        Description = "+1 speed";
        Cost = "+2" + GameManager.Get("wheel");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseWheelCount += 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.rotRange.y++;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}