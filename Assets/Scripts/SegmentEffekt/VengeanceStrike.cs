using UnityEngine;

[Effect("VengeanceStrike")]
public class VengeanceStrike : WheelEffekt
{
    public VengeanceStrike()
    {
        name = "Vengeance Strike";
        Symbol = "sword";
        Description = "+5 " + GameManager.Get("damage") + " +1 per 10 missing " + GameManager.Get("life") + " (max 15)";
        Cost = "-2 base " + GameManager.Get("armor");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        int missingLife = Mathf.Max(0, contex.maxLife - contex.life);
                contex.damage += Mathf.Min(15, 5 + missingLife / 10);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 2;
    }
}
