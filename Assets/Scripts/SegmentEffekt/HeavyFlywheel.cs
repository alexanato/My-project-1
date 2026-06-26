using UnityEngine;

[Effect("HeavyFlywheel")]
public class HeavyFlywheel : WheelEffekt
{
    public HeavyFlywheel()
    {
        name = "Heavy Flywheel";
        Symbol = "wheel";
        Description = "Spend 6 " + GameManager.Get("armor") + " for +1 " + GameManager.Get("wheel") + "; otherwise gain 4 " + GameManager.Get("armor");
        Cost = "+0.25 speed";
        type = EffektType.WHEEL;
    }

    public override void doCost(Wheel contex)
    {
        contex.ChangeWheelSpeed(0.25f);
    }

    public override void DoEffekt(Wheel contex)
    {
        if (contex.armor >= 6)
                {
                    contex.armor -= 6;
                    contex.AddBonusWheels(1);
                }
                else
                {
                    contex.armor += 4;
                }
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
