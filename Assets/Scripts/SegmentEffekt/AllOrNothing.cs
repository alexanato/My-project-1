using UnityEngine;

[Effect("AllOrNothing")]
public class AllOrNothing : WheelEffekt
{
    public AllOrNothing()
    {
        name = "All Or Nothing";
        Symbol = "sword";
        Description = GameManager.Get("damage") + " +0.5 per " + GameManager.Get("luck") + " (max 20), +2 " + GameManager.Get("weak");
        Cost = "-5 " + GameManager.Get("luck");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddLuck(-5);
    }

    public override void DoEffekt(Wheel contex)
    {
        int bonus = Mathf.Min(20, contex.luck / 2);
                contex.damage += bonus;
                contex.weak += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 5;
    }
}
