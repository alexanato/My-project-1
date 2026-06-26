using UnityEngine;

[Effect("CurseRigorMortis")]
public class CurseRigorMortis : WheelEffekt
{
    public CurseRigorMortis()
    {
        name = "Rigor Mortis";
        Symbol = "curse";
        Description = "Curse: +3 " + GameManager.Get("poison") + " and end your turn";
        Cost = "+1 base " + GameManager.Get("target");
        type = EffektType.CURSE;
    }

    public override bool CanBeTriggeredAsSecondary => false;

    public override void doCost(Wheel contex)
    {
        contex.baseTarget += 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.poisen += 3;
                contex.EndCurrentTurn();
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
