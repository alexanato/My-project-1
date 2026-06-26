using UnityEngine;

[Effect("Decomposition")]
public class Decomposition : WheelEffekt
{
    public Decomposition()
    {
        name = "Decomposition";
        Symbol = "poison";
        Description = "Enemy " + GameManager.Get("poison") + " +50% (max +8); self -3 " + GameManager.Get("life");
        Cost = "-1 base " + GameManager.Get("target");
        type = EffektType.POISON;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        int increase = Mathf.Clamp(contex.EnemyWheel.poisen / 2, 2, 8);
                contex.EnemyWheel.poisen += increase;
                contex.life = Mathf.Max(1, contex.life - 3);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}
