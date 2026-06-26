using UnityEngine;

[Effect("LastGasp")]
public class LastGasp : WheelEffekt
{
    public LastGasp()
    {
        name = "Last Gasp";
        Symbol = "poison";
        Description = "At <=50% " + GameManager.Get("life") + ": enemy " + GameManager.Get("poison") + " +50% (max +10); else +3";
        Cost = "-10 " + GameManager.Get("luck");
        type = EffektType.POISON;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddLuck(-10);
    }

    public override void DoEffekt(Wheel contex)
    {
        if (contex.life * 2 <= contex.maxLife)
                {
                    contex.EnemyWheel.poisen += Mathf.Min(10, Mathf.Max(2, contex.EnemyWheel.poisen / 2));
                }
                else
                {
                    contex.EnemyWheel.poisen += 3;
                }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 10;
    }
}
