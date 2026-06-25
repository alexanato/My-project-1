using UnityEngine;

[Effect("ChainReaction")]
public class ChainReaction : WheelEffekt
{
    // Original Rad-Effekt: Wenn du in dieser Runde schon einmal gedreht hast, erhältst du +2 Wheel.
    // Original Kauf-Modifikator: -1 Basis-Wheel.
    public ChainReaction()
    {
        name = "Chain Reaction";
        Symbol = "wheel";
        Description = "first spin +2"+ GameManager.Get("wheel")+ "+3"+GameManager.Get("life");
        Cost = "-1"+GameManager.Get("wheel");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseWheelCount -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        if(contex.x == 2)
        {
            contex.wheelCount += 2;
        }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseWheelCount >= 2;
    }
}