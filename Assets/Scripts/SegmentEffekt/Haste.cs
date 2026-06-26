using UnityEngine;

[Effect("Haste")]
public class Haste : WheelEffekt
{
    public Haste()
    {
        name = "Haste";
        Symbol = "wheel";
        Description = "+10 " + GameManager.Get("damage") + " and +2 " + GameManager.Get("weak");
        Cost = "+0.5 speed";
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.ChangeWheelSpeed(0.5f);
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += 10;
                contex.weak += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
