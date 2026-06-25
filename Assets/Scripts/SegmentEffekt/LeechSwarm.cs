using UnityEngine;

[Effect("LeechSwarm")]
public class LeechSwarm : WheelEffekt
{
    // Original Rad-Effekt: +1 Leben (Heilung) pro erfolgreichem Treffer in diesem Dreh.
    // Original Kauf-Modifikator: -1 Basis-Schaden, -1 Basis-Wheel.
    public LeechSwarm()
    {
        name = "Leech Swarm";
        Symbol = "life";
        Description = "+2 " + GameManager.Get("life") + " / spined wheel";
        Cost = "-5" + GameManager.Get("life");
    }

    public override void doCost(Wheel contex)
    {
        contex.life -= 5;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life += contex.x;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}