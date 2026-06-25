using UnityEngine;

[Effect("Karma")]
public class Karma : WheelEffekt
{
    // Original Rad-Effekt: Heilt dich um den absoluten Wert deines am tiefsten im Minus stehenden permanenten Stats.
    // Original Kauf-Modifikator: -1 Basis-Wheel.
    public Karma()
    {
        name = "Karma";
        Symbol = "life";
        Description = "+"+GameManager.Get("life") + " = lowest base stat";
        Cost = "-2"+GameManager.Get("armor");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life += Mathf.Min(contex.baseArmor, contex.baseDamage, contex.baseTarget);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 2;
    }
}