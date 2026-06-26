using UnityEngine;

[Effect("TacticalStop")]
public class TacticalStop : WheelEffekt
{
    public TacticalStop()
    {
        name = "Tactical Stop";
        Symbol = "target";
        Description = "+7 " + GameManager.Get("damage") + " and +1 " + GameManager.Get("target");
        Cost = "-5 " + GameManager.Get("luck");
        type = EffektType.TARGET;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddLuck(-5);
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += 7;
                contex.target += 1;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 5;
    }
}
