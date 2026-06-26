using UnityEngine;

[Effect("PrecisionStrike")]
public class PrecisionStrike : WheelEffekt
{
    public PrecisionStrike()
    {
        name = "Precision Strike";
        Symbol = "target";
        Description = "First spin: +2 " + GameManager.Get("target") + "; otherwise +8 " + GameManager.Get("damage");
        Cost = "+4 " + GameManager.Get("weak");
        type = EffektType.TARGET;
    }

    public override void doCost(Wheel contex)
    {
        contex.weak += 4;
    }

    public override void DoEffekt(Wheel contex)
    {
        if (contex.x <= 2)
                {
                    contex.target += 2;
                }
                else
                {
                    contex.damage += 8;
                }
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
