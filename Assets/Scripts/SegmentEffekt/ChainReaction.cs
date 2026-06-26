using UnityEngine;

[Effect("ChainReaction")]
public class ChainReaction : WheelEffekt
{
    public ChainReaction()
    {
        name = "Chain Reaction";
        Symbol = "wheel";
        Description = "First spin: +1 " + GameManager.Get("wheel") + "; otherwise +5 " + GameManager.Get("damage");
        Cost = "-1 base " + GameManager.Get("target");
        type = EffektType.WHEEL;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        if (contex.x <= 2)
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
