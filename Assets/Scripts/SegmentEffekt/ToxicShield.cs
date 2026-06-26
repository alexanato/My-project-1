using UnityEngine;

[Effect("ToxicShield")]
public class ToxicShield : WheelEffekt
{
    public ToxicShield()
    {
        name = "Toxic Shield";
        Symbol = "armor";
        Description = "+7 " + GameManager.Get("armor") + " and enemy +2 " + GameManager.Get("poison");
        Cost = "-1 base " + GameManager.Get("armor");
        type = EffektType.DEFENSE;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor += 7;
                contex.EnemyWheel.poisen += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 1;
    }
}
