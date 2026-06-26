using UnityEngine;

[Effect("ThousandCuts")]
public class ThousandCuts : WheelEffekt
{
    public ThousandCuts()
    {
        name = "Thousand Cuts";
        Symbol = "sword";
        Description = "+3 " + GameManager.Get("target") + ", lose 8 current " + GameManager.Get("damage") + " and gain 2 " + GameManager.Get("weak");
        Cost = "-1 base " + GameManager.Get("target");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage = Mathf.Max(0, contex.damage - 8);
                contex.target += 3;
                contex.weak += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}
