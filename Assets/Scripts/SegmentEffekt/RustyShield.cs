using UnityEngine;

[Effect("RustyShield")]
public class RustyShield : WheelEffekt
{
    // Original Rad-Effekt: +5 Armor, du erhältst +2 Schwäche.
    // Original Kauf-Modifikator: +2 Basis-Schaden.
    public RustyShield()
    {
        name = "Rusty Shield";
        Symbol = "broken";
        Description = "+5 " + GameManager.Get("armor") + " +2 " + GameManager.Get("broken");

        Cost = "+2" + GameManager.Get("damage");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage += 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor += 5;
        contex.weak += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}