using UnityEngine;

[Effect("Attrition")]
public class Attrition : WheelEffekt
{
    public Attrition()
    {
        name = "Attrition";
        Symbol = "target";
        Description = "Enemy +2 " + GameManager.Get("weak") + " (+3 if poisoned)";
        Cost = "-4 " + GameManager.Get("luck");
        type = EffektType.TARGET;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddLuck(-4);
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.EnemyWheel.weak += contex.EnemyWheel.poisen >= 4 ? 3 : 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 4;
    }
}
