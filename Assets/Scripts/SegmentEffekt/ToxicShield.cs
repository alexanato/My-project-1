using UnityEngine;

[Effect("ToxicShield")]
public class ToxicShield : WheelEffekt
{
    // Original Rad-Effekt: Toxischer Schild +5 Armor. Gegner erhält Gift in Höhe des abgewehrten Schadens dieser Runde.
    // Original Kauf-Modifikator: -2 Basis-Rüstung.
    public ToxicShield()
    {
        name = "Toxic Shield";
        Symbol = "armor";
        Description = "+5 " + GameManager.Get("armor") + "+2" + GameManager.Get("poison");
        Cost = "-1" + GameManager.Get("armor");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor += 5;
        contex.poisen += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 1;
    }
}