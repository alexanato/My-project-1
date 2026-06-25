using UnityEngine;

[Effect("HeavyFlywheel")]
public class HeavyFlywheel : WheelEffekt
{
    // Original Rad-Effekt: +1 Wheel, du verlierst dafür sofort 5 Armor.
    // Original Kauf-Modifikator: +1 Basis-Rüstung.
    public HeavyFlywheel()
    {
        name = "Heavy Flywheel";
        Symbol = "wheel";
        Description = "+2 " + GameManager.Get("wheel") + "-10 " + GameManager.Get("armor");
        Cost = "+1" + GameManager.Get("armor");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor += 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        if( contex.armor >= 10)
        {
            contex.armor -= 10;
            contex.wheelCount += 2;
        }
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}