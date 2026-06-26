using UnityEngine;

[Effect("Overload")]
public class Overload : WheelEffekt
{
    public Overload()
    {
        name = "Overload";
        Symbol = "sword";
        Description = "+12 " + GameManager.Get("damage") + " and +3 " + GameManager.Get("weak");
        Cost = "-1 base " + GameManager.Get("damage");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += 12;
                contex.weak += 3;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 1;
    }
}
