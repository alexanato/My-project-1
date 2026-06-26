using UnityEngine;

[Effect("Focus")]
public class Focus : WheelEffekt
{
    public Focus()
    {
        name = "Focus";
        Symbol = "target";
        Description = "Trigger one neighboring non-curse segment and gain +1 " + GameManager.Get("target");
        Cost = "-1 base " + GameManager.Get("armor");
        type = EffektType.UTILITY;
    }

    public override bool CanBeTriggeredAsSecondary => false;

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        int direction = Random.Range(0, 2) == 0 ? -1 : 1;
        int index = (contex.getCurrentColor() + direction + 8) % 8;
        contex.TryTriggerSecondaryEffect(index);
        contex.target += 1;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 1;
    }
}
