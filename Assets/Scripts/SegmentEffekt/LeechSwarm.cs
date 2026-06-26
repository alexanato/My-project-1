using UnityEngine;

[Effect("LeechSwarm")]
public class LeechSwarm : WheelEffekt
{
    public LeechSwarm()
    {
        name = "Leech Swarm";
        Symbol = "life";
        Description = "Enemy +2 " + GameManager.Get("poison") + "; heal half enemy " + GameManager.Get("poison") + " (max 6)";
        Cost = "-6 " + GameManager.Get("life");
        type = EffektType.LIFE;
    }

    public override void doCost(Wheel contex)
    {
        contex.life -= 6;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.EnemyWheel.poisen += 2;
                contex.Heal(Mathf.Min(6, contex.EnemyWheel.poisen / 2));
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.life > 6;
    }
}
