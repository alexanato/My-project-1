using UnityEngine;

[Effect("WeaknessCascade")]
public class WeaknessCascade : WheelEffekt
{
    public WeaknessCascade()
    {
        name = "Weakness Cascade";
        Symbol = "target";
        Description = "+2 " + GameManager.Get("damage") + " per enemy " + GameManager.Get("weak") + " (max 20)";
        Cost = "-1 base " + GameManager.Get("target");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += Mathf.Min(20, contex.EnemyWheel.weak * 2);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}
