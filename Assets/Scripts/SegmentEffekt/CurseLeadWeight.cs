using UnityEngine;

[Effect("CurseLeadWeight")]
public class CurseLeadWeight : WheelEffekt
{
    public CurseLeadWeight()
    {
        name = "Lead Weight";
        Symbol = "curse";
        Description = "Curse: end your turn and gain 2 " + GameManager.Get("weak");
        Cost = "+1 base " + GameManager.Get("wheel") + ", +1 speed";
        type = EffektType.CURSE;
    }

    public override bool CanBeTriggeredAsSecondary => false;

    public override void doCost(Wheel contex)
    {
        contex.AddBaseWheels(1);
        contex.ChangeWheelSpeed(1f);
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.weak += 2;
        contex.EndCurrentTurn();
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseWheelCount < contex.MaxBaseWheelCount;
    }
}
