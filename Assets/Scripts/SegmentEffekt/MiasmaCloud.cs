using UnityEngine;

[Effect("MiasmaCloud")]
public class MiasmaCloud : WheelEffekt
{
    // Original Rad-Effekt: Gegner erhält 1 Gift für jeden negativen permanenten Stat, den du aktuell besitzt.
    // Original Kauf-Modifikator: -2 Base Armor.
    public MiasmaCloud()
    {
        name = "Miasma Cloud";
        Symbol = "poison";
        Description = "+1 " + GameManager.Get("poison") + "per" + GameManager.Get("armor");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.EnemyWheel.poisen += contex.armor;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >=2;
    }
}