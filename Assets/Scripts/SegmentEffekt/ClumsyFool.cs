using UnityEngine;

[Effect("ClumsyFool")]
public class ClumsyFool : WheelEffekt
{
    public ClumsyFool()
    {
        name = "Clumsy Fool";
        Symbol = "broken";
        Description = "Lose 3 " + GameManager.Get("life") + " and gain 5 " + GameManager.Get("weak");
        Cost = "+1 base " + GameManager.Get("damage") + " and +5 " + GameManager.Get("luck");
        type = EffektType.UTILITY;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage += 1;
                contex.AddLuck(5);
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life = Mathf.Max(1, contex.life - 3);
                contex.weak += 5;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
