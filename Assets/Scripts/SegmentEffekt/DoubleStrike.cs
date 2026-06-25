using UnityEngine;

[Effect("DoubleStrike")]
public class DoubleStrike : WheelEffekt
{
    // Original Rad-Effekt: +1 Mehrfachtreffer (für diesen Dreh), +2 Damage.
    // Original Kauf-Modifikator: -1 Basis-Schaden.
    public DoubleStrike()
    {
        name = "Double Strike";
        Symbol = "sword";
        Description = "+1 "+ GameManager.Get("target") + " +2 " + GameManager.Get("damage");
        Cost = "-1" + GameManager.Get("target");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += 2;
        contex.target += 1;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 2;
    }
}