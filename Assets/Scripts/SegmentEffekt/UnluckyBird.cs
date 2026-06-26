using UnityEngine;

[Effect("UnluckyBird")]
public class UnluckyBird : WheelEffekt
{
    public UnluckyBird()
    {
        name = "Unlucky Bird";
        Symbol = "broken";
        Description = "+1 " + GameManager.Get("damage") + " per " + GameManager.Get("weak") + " and +1 per 2 " + GameManager.Get("poison") + " (max 16); self -2 " + GameManager.Get("life");
        Cost = "+5 " + GameManager.Get("luck");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddLuck(5);
    }

    public override void DoEffekt(Wheel contex)
    {
        int bonus = Mathf.Min(16, contex.weak + contex.poisen / 2);
                contex.damage += bonus;
                contex.life = Mathf.Max(1, contex.life - 2);
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
