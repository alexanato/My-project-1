using UnityEngine;

[Effect("SlowMotion")]
public class SlowMotion : WheelEffekt
{
    public SlowMotion()
    {
        name = "Slow Motion";
        Symbol = "bell";
        Description = "+7 " + GameManager.Get("armor") + " and +1 " + GameManager.Get("target");
        Cost = "+0.75 speed";
        type = EffektType.DEFENSE;
    }

    public override void doCost(Wheel contex)
    {
        contex.ChangeWheelSpeed(0.75f);
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor += 7;
                contex.target += 1;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
