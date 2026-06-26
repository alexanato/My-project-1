using UnityEngine;

[Effect("GlassCannon")]
public class GlassCannon : WheelEffekt
{
    public GlassCannon()
    {
        name = "Glass Cannon";
        Symbol = "glass";
        Description = "Convert up to 12 temporary " + GameManager.Get("armor") + " into " + GameManager.Get("damage");
        Cost = "-2 base " + GameManager.Get("damage");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        int spent = Mathf.Min(12, contex.armor);
                contex.armor -= spent;
                contex.damage += spent;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 2;
    }
}
