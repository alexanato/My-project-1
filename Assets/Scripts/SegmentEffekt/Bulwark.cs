using UnityEngine;

[Effect("Bulwark")]
public class Bulwark : WheelEffekt
{
    public Bulwark()
    {
        name = "Bulwark";
        Symbol = "armor";
        Description = "Gain 6-12 " + GameManager.Get("armor") + " based on total armor";
        Cost = "-2 base " + GameManager.Get("armor");
        type = EffektType.DEFENSE;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        int bonus = Mathf.Clamp(contex.TotalArmor / 2, 6, 12);
                contex.armor += bonus;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 2;
    }
}
