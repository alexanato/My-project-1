using UnityEngine;

[Effect("AllOrNothing")]
public class AllOrNothing : WheelEffekt
{
    // Original Rad-Effekt: Verbraucht dein gesamtes aktuelles Glück (setzt es auf 0). Verursacht Damage = Verbrauchtes Glück × 2.
    // Original Kauf-Modifikator: +10 Glück.
    public AllOrNothing()
    {
        name = "All Or Nothing";
        Symbol = "sword";
        Description = "+2"+ GameManager.Get("damage")+"per Luck but reset" + GameManager.Get("luck");
        Cost = "+10"+GameManager.Get("luck");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.luck += 10;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += contex.luck * 2;
        contex.luck = 0;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}