using UnityEngine;

public class ToxicSting : WheelEffekt
{
    public ToxicSting()
    {
        name = "ToxicSting";
        Description = "+3"+GameManager.Get("damage") + "+2" + GameManager.Get("poison");
        Cost = "-1" + GameManager.Get("damage");
        Symbol = "sword";
    }
    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += 3;
        contex.EnemyWheel.poisen += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 1;
    }
}
