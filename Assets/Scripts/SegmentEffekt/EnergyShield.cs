using UnityEngine;

[Effect("EnergyShield")]
public class EnergyShield : WheelEffekt
{
    // Original Rad-Effekt: Deine Armor blockt in dieser Runde auch den eingehenden Giftschaden.
    // Original Kauf-Modifikator: -2 Giftresistenz.
    public EnergyShield()
    {
        name = "Energy Shield";
        Symbol = "armor";
        Description = "+1"+GameManager.Get("armor") + "per 10" + GameManager.Get("luck");
        Cost = "-2" + GameManager.Get("armor");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor += contex.luck / 10;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >=2;
    }
}