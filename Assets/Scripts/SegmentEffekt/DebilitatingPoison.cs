using UnityEngine;

[Effect("DebilitatingPoison")]
public class DebilitatingPoison : WheelEffekt
{
    public DebilitatingPoison()
    {
        name = "Debilitating Poison";
        Symbol = "poison";
        Description = "Enemy +2 " + GameManager.Get("poison") + "; if already poisoned, +3 " + GameManager.Get("weak");
        Cost = "-1 base " + GameManager.Get("armor");
        type = EffektType.POISON;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        if (contex.EnemyWheel.poisen >= 4)
                {
                    contex.EnemyWheel.weak += 3;
                }
                else
                {
                    contex.EnemyWheel.poisen += 2;
                }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 1;
    }
}
