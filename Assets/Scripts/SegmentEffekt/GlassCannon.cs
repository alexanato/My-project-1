using UnityEngine;

[Effect("GlassCannon")]
public class GlassCannon : WheelEffekt
{
    // Original Rad-Effekt: Du verlierst alle Armor. +1 Damage pro 1 verlorene Armor.
    // Original Kauf-Modifikator: -2 Basis-Rüstung.
    public GlassCannon()
    {
        name = "Glass Cannon";
        Symbol = "glass";
        Description = "per" + GameManager.Get("armor") + "+1" + GameManager.Get("damage") + " reset" + GameManager.Get("armor");
        Cost = "-3" + GameManager.Get("damage");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 3;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += contex.armor;
        contex.armor = 0;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 3;
    }
}