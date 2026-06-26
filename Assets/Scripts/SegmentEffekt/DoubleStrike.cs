using UnityEngine;

[Effect("DoubleStrike")]
public class DoubleStrike : WheelEffekt
{
    public DoubleStrike()
    {
        name = "Double Strike";
        Symbol = "sword";
        Description = "+3 " + GameManager.Get("damage") + " and +1 " + GameManager.Get("target");
        Cost = "-2 base " + GameManager.Get("damage");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += 3;
                contex.target += 1;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 2;
    }
}
