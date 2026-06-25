using UnityEngine;

[Effect("ExtraSpin")]
public class ExtraSpin : WheelEffekt
{
    // Original Rad-Effekt: +1 Wheel.
    // Original Kauf-Modifikator: -1 Basis-Wheel.
    public ExtraSpin()
    {
        name = "Extra Spin";
        Symbol = "wheel";
        Description = "+1 " + GameManager.Get("wheel");
        Cost = "+3"+ GameManager.Get("armor");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor += 3;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.wheelCount += 1;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}