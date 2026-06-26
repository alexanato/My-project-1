using UnityEngine;

[Effect("Vertigo")]
public class Vertigo : WheelEffekt
{
    public Vertigo()
    {
        name = "Vertigo";
        Symbol = "wheel";
        Description = "+1 " + GameManager.Get("wheel") + " and +4 " + GameManager.Get("weak");
        Cost = "+2 base " + GameManager.Get("armor");
        type = EffektType.WHEEL;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor += 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.AddBonusWheels(1);
                contex.weak += 4;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
