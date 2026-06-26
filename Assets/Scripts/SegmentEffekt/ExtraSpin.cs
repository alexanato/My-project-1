using UnityEngine;

[Effect("ExtraSpin")]
public class ExtraSpin : WheelEffekt
{
    public ExtraSpin()
    {
        name = "Extra Spin";
        Symbol = "wheel";
        Description = "+1 " + GameManager.Get("wheel") + " and +2 " + GameManager.Get("weak");
        Cost = "-1 base " + GameManager.Get("armor");
        type = EffektType.WHEEL;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.AddBonusWheels(1);
                contex.weak += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 1;
    }
}
