using UnityEngine;

[Effect("Jackpot")]
public class Jackpot : WheelEffekt
{
    public Jackpot()
    {
        name = "Jackpot";
        Symbol = "wheel";
        Description = "20%: +2 " + GameManager.Get("wheel") + "; otherwise +4 " + GameManager.Get("damage");
        Cost = "-8 " + GameManager.Get("luck");
        type = EffektType.LUCK;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddLuck(-8);
    }

    public override void DoEffekt(Wheel contex)
    {
        if (Random.Range(0, 100) < 20)
                {
                    contex.AddBonusWheels(2);
                }
                else
                {
                    contex.damage += 4;
                }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 8;
    }
}
