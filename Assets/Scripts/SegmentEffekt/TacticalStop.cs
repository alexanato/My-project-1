using UnityEngine;

[Effect("TacticalStop")]
public class TacticalStop : WheelEffekt
{
    // Original Rad-Effekt: Stoppt das Rad beim nächsten Dreh automatisch exakt auf der gegenüberliegenden Seite.
    // Original Kauf-Modifikator: -2 WheelSpeed.
    public TacticalStop()
    {
        name = "Tactical Stop";
        Symbol = "target";
        Description = "+10"+GameManager.Get("damage") +"2 speed";
        Cost = "+10" + GameManager.Get("luck");
    }

    public override void doCost(Wheel contex)
    {
        contex.luck += 10;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.rotRange.y += 2;
        contex.damage += 10;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}