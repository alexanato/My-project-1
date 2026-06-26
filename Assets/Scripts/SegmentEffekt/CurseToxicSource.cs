using UnityEngine;

[Effect("CurseToxicSource")]
public class CurseToxicSource : WheelEffekt
{
    public CurseToxicSource()
    {
        name = "Toxic Source";
        Symbol = "curse";
        Description = "Curse: self +8 " + GameManager.Get("poison") + ", enemy -4 " + GameManager.Get("poison");
        Cost = "+3 " + GameManager.Get("vacine") + " and +8 " + GameManager.Get("luck");
        type = EffektType.CURSE;
    }

    public override bool CanBeTriggeredAsSecondary => false;

    public override void doCost(Wheel contex)
    {
        contex.vacine += 3;
                contex.AddLuck(8);
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.poisen += 8;
                contex.EnemyWheel.poisen = Mathf.Max(0, contex.EnemyWheel.poisen - 4);
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
