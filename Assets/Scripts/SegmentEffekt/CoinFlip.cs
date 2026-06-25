using UnityEngine;

[Effect("CoinFlip")]
public class CoinFlip : WheelEffekt
{
    // Original Rad-Effekt: 50% Chance auf +15 Damage, 50% Chance auf 5 Schaden an dich selbst.
    // Original Kauf-Modifikator: +5 Glück.
    public CoinFlip()
    {
        name = "Coin Flip";
        Symbol = "none";
        Description = "50%:+10" + GameManager.Get("life") + "/50%: -10 " + GameManager.Get("life");
        Cost = "+5"+ GameManager.Get("luck");
    }

    public override void doCost(Wheel contex)
    {
        contex.luck += 5;
    }

    public override void DoEffekt(Wheel contex)
    {
        int r = Random.Range(0, 2);
        if( r == 0) 
        {
            contex.life -= 10;
        }
        else
        {
            contex.life += 10;
        }
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}