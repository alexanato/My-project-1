using UnityEngine;

[Effect("ClumsyFool")]
public class ClumsyFool : WheelEffekt
{
    public ClumsyFool()
    {
        name = "Clumsy Fool";
        Symbol = "broken";
        Description = "Lose 3 " + GameManager.Get("life") + " and gain 3 " + GameManager.Get("weak");
        Cost = "+1 base " + GameManager.Get("wheel");
        type = EffektType.UTILITY;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddBaseWheels(1);
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life = Mathf.Max(1, contex.life - 3);
        contex.weak += 3;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseWheelCount < contex.MaxBaseWheelCount;
    }
}
