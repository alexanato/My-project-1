using UnityEngine;

[Effect("LuckyHit")]
public class LuckyHit : WheelEffekt
{
    // Original Rad-Effekt: Verursacht Damage = (Aktuelles Glück / 5).
    // Original Kauf-Modifikator: -3 base damage.
    public LuckyHit()
    {
        name = "Lucky Hit";
        Symbol = "sword";
        Description =   "per 5"+ GameManager.Get("luck") + "+1" + GameManager.Get("damage");
        Cost = "-3" + GameManager.Get("damage");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 3;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += contex.luck / 5;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 3;
    }
}