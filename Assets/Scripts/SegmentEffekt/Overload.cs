using UnityEngine;

[Effect("Overload")]
public class Overload : WheelEffekt
{
    // Original Rad-Effekt: +3 Wheel, aber die Rad-Farben werden für diese Runde unsichtbar.
    // Original Kauf-Modifikator: +2 Basis-Mehrfachtreffer.
    public Overload()
    {
        name = "Overload";
        Symbol = "wheel";
        Description = "50%  +1 base" + GameManager.Get("damage");
        Cost = "-1"+GameManager.Get("damage");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        if (Random.Range(0, 3) != 0) return;
        contex.baseDamage += 1;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 1;
    }
}