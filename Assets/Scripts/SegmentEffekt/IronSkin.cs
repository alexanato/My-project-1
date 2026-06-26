using UnityEngine;

[Effect("IronSkin")]
public class IronSkin : WheelEffekt
{
    public IronSkin()
    {
        name = "Iron Skin";
        Symbol = "armor";
        Description = "+9 " + GameManager.Get("armor");
        Cost = "+0.5 speed";
        type = EffektType.DEFENSE;
    }

    public override void doCost(Wheel contex)
    {
        contex.ChangeWheelSpeed(0.5f);
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor += 9;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
