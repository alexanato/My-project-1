using UnityEngine;

[Effect("LuckyHit")]
public class LuckyHit : WheelEffekt
{
    public LuckyHit()
    {
        name = "Lucky Hit";
        Symbol = "sword";
        Description = "+1 " + GameManager.Get("damage") + " per 5 " + GameManager.Get("luck") + " (max 15)";
        Cost = "-2 base " + GameManager.Get("damage");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += Mathf.Min(15, contex.luck / 5);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 2;
    }
}
