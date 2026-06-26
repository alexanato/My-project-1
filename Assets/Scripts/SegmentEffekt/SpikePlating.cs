using UnityEngine;

[Effect("SpikePlating")]
public class SpikePlating : WheelEffekt
{
    public SpikePlating()
    {
        name = "Spike Plating";
        Symbol = "armor";
        Description = "+6 " + GameManager.Get("armor") + " and up to +6 " + GameManager.Get("damage") + " from temporary armor";
        Cost = "-2 base " + GameManager.Get("armor");
        type = EffektType.DEFENSE;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor += 6;
                contex.damage += Mathf.Min(6, contex.armor / 3);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 2;
    }
}
