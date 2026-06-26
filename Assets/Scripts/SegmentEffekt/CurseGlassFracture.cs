using UnityEngine;

[Effect("CurseGlassFracture")]
public class CurseGlassFracture : WheelEffekt
{
    public CurseGlassFracture()
    {
        name = "Glass Fracture";
        Symbol = "curse";
        Description = "Curse: lose temporary " + GameManager.Get("armor") + " and 5 " + GameManager.Get("life");
        Cost = "+4 base " + GameManager.Get("armor");
        type = EffektType.CURSE;
    }

    public override bool CanBeTriggeredAsSecondary => false;

    public override void doCost(Wheel contex)
    {
        contex.baseArmor += 4;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor = 0;
                contex.life = Mathf.Max(1, contex.life - 5);
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
