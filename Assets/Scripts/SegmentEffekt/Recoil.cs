using UnityEngine;

[Effect("Recoil")]
public class Recoil : WheelEffekt
{
    public Recoil()
    {
        name = "Recoil";
        Symbol = "broken";
        Description = "+1 " + GameManager.Get("wheel") + ", lose 5 current " + GameManager.Get("damage") + ", gain 2 " + GameManager.Get("weak");
        Cost = "+6 " + GameManager.Get("luck");
        type = EffektType.WHEEL;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddLuck(6);
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.AddBonusWheels(1);
                contex.damage = Mathf.Max(0, contex.damage - 5);
                contex.weak += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
