using UnityEngine;

[Effect("PerpetuumMobile")]
public class PerpetuumMobile : WheelEffekt
{
    public PerpetuumMobile()
    {
        name = "Perpetuum Mobile";
        Symbol = "wheel";
        Description = "At 0 temporary " + GameManager.Get("armor") + ": +1 " + GameManager.Get("wheel") + " and +3 " + GameManager.Get("armor") + "; else +6 " + GameManager.Get("armor");
        Cost = "+1 base " + GameManager.Get("wheel") + ", +6 " + GameManager.Get("poison");
        type = EffektType.WHEEL;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddBaseWheels(1);
        contex.poisen += 6;
    }

    public override void DoEffekt(Wheel contex)
    {
        if (contex.armor == 0)
        {
            contex.AddBonusWheels(1);
            contex.armor += 3;
        }
        else
        {
            contex.armor += 6;
        }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseWheelCount < contex.MaxBaseWheelCount;
    }
}
