using UnityEngine;

[Effect("EnergyShield")]
public class EnergyShield : WheelEffekt
{
    public EnergyShield()
    {
        name = "Energy Shield";
        Symbol = "armor";
        Description = "+3 " + GameManager.Get("armor") + " +1 per 10 " + GameManager.Get("luck") + " (max 10)";
        Cost = "-5 " + GameManager.Get("luck");
        type = EffektType.DEFENSE;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddLuck(-5);
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor += Mathf.Min(10, 3 + contex.luck / 10);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 5;
    }
}
