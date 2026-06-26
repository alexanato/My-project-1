using UnityEngine;

[Effect("CoinFlip")]
public class CoinFlip : WheelEffekt
{
    public CoinFlip()
    {
        name = "Coin Flip";
        Symbol = "none";
        Description = "50%: +12 " + GameManager.Get("damage") + "; 50%: -6 " + GameManager.Get("life");
        Cost = "-4 " + GameManager.Get("luck");
        type = EffektType.LUCK;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddLuck(-4);
    }

    public override void DoEffekt(Wheel contex)
    {
        if (Random.Range(0, 2) == 0)
                {
                    contex.damage += 12;
                }
                else
                {
                    contex.life = Mathf.Max(1, contex.life - 6);
                }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 4;
    }
}
