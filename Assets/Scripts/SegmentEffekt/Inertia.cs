using UnityEngine;

[Effect("Inertia")]
public class Inertia : WheelEffekt
{
    public Inertia()
    {
        name = "Inertia";
        Symbol = "wheel";
        Description = "First spin: +1 " + GameManager.Get("wheel") + "; otherwise +6 " + GameManager.Get("armor");
        Cost = "-8 " + GameManager.Get("life");
        type = EffektType.WHEEL;
    }

    public override void doCost(Wheel contex)
    {
        contex.life -= 8;
    }

    public override void DoEffekt(Wheel contex)
    {
        if (contex.x <= 2)
                {
                    contex.AddBonusWheels(1);
                }
                else
                {
                    contex.armor += 6;
                }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.life > 8;
    }
}
