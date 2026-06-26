using UnityEngine;

[Effect("ArmorBreak")]
public class ArmorBreak : WheelEffekt
{
    public ArmorBreak()
    {
        name = "Armor Break";
        Symbol = "broken";
        Description = "Enemy -6 " + GameManager.Get("armor") + " and +2 " + GameManager.Get("weak");
        Cost = "-1 " + GameManager.Get("damage");
        type = EffektType.TARGET;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.EnemyWheel.armor = Mathf.Max(0, contex.EnemyWheel.armor - 6);
                contex.EnemyWheel.weak += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 1;
    }
}
