using UnityEngine;

[Effect("EchoBlade")]
public class EchoBlade : WheelEffekt
{
    public EchoBlade()
    {
        name = "Echo Blade";
        Symbol = "sword";
        Description = "+2 " + GameManager.Get("damage") + " per total " + GameManager.Get("target") + " (max 8)";
        Cost = "-1 base " + GameManager.Get("target");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += Mathf.Min(8, contex.TotalTargets * 2);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}
