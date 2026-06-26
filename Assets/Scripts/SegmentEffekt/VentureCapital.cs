using UnityEngine;

[Effect("VentureCapital")]
public class VentureCapital : WheelEffekt
{
    public VentureCapital()
    {
        name = "Venture Capital";
        Symbol = "none";
        Description = "Lose 8 " + GameManager.Get("life") + "; gain +14 " + GameManager.Get("damage") + " and +1 " + GameManager.Get("target");
        Cost = "+12 " + GameManager.Get("life");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.maxLife += 12;
                contex.life += 12;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life = Mathf.Max(1, contex.life - 8);
                contex.damage += 14;
                contex.target += 1;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
