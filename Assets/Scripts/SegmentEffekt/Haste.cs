using UnityEngine;

[Effect("Haste")]
public class Haste : WheelEffekt
{
    // Original Rad-Effekt: +1 WheelSpeed (Rad dreht sich extrem schnell), +10 Damage.
    // Original Kauf-Modifikator: -1 speed.
    public Haste()
    {
        name = "Haste";
        Symbol = "wheel";
        Description = "+1 speed +10 " + GameManager.Get("damage");
    }

    public override void doCost(Wheel contex)
    {
        contex.rotRange.y -= 1;
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