using UnityEngine;

[Effect("LastGasp")]
public class LastGasp : WheelEffekt
{
    // Original Rad-Effekt: Verdoppelt die Gift-Stapel auf dem Gegner.
    // Original Kauf-Modifikator: -10 Glück.
    public LastGasp()
    {
        name = "Last Gasp";
        Symbol = "poison";
        Description = "2x " + GameManager.Get("poison") + "enemy";
        Cost = "-15" + GameManager.Get("luck");
    }

    public override void doCost(Wheel contex)
    {
        contex.luck -= 15;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.EnemyWheel.poisen *= 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 15;
    }
}