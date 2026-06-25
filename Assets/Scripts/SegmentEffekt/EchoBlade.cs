using UnityEngine;

[Effect("EchoBlade")]
public class EchoBlade : WheelEffekt
{
    // Original Rad-Effekt: Verursacht 1 Damage pro (Gesamt-Mehrfachtreffer × 2).
    // Original Kauf-Modifikator: -1 Basis-Mehrfachtreffer.
    public EchoBlade()
    {
        name = "Echo Blade";
        Symbol = "sword";
        Description = "+1" + GameManager.Get("damage")+"per"+ GameManager.Get("target");
    }

    public override void doCost(Wheel contex)
    {
        contex.target -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += contex.target;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}