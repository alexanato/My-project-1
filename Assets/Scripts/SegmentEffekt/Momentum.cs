using UnityEngine;

[Effect("Momentum")]
public class Momentum : WheelEffekt
{
    public Momentum()
    {
        name = "Momentum";
        Symbol = "wheel";
        Description = "Second or later spin: +1 " + GameManager.Get("wheel") + "; first spin: +5 " + GameManager.Get("damage");
        Cost = "-1 base " + GameManager.Get("target");
        type = EffektType.WHEEL;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        if (contex.x >= 4)
                {
                    contex.AddBonusWheels(1);
                }
                else
                {
                    contex.damage += 5;
                }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}
