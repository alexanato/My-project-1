using UnityEngine;

[Effect("Bulwark")]
public class Bulwark : WheelEffekt
{
    // Original Rad-Effekt: Verdoppelt deine aktuelle Rüstung für diese Runde.
    // Original Kauf-Modifikator: -3 Basis-Rüstung.
    public Bulwark()
    {
        name = "Bulwark";
        Symbol = "armor";
        Description = "2x " + GameManager.Get("armor");
        Cost = "-3" + GameManager.Get("armor");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 3;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor *= 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 3;
    }
}