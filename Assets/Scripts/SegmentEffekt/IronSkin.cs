using UnityEngine;

[Effect("IronSkin")]
public class IronSkin : WheelEffekt
{
    // Original Rad-Effekt: +10 Armor.
    // Original Kauf-Modifikator: +2 WheelSpeed.
    public IronSkin()
    {
        name = "Iron Skin";
        Symbol = "armor";
        Description = "+10 " + GameManager.Get("armor");
        Cost = "+1 speed";
    }

    public override void doCost(Wheel contex)
    {
        contex.rotRange.y += 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor += 10;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}