using UnityEngine;

[Effect("NutrientSlime")]
public class NutrientSlime : WheelEffekt
{
    // Original Rad-Effekt: Du erhältst 5 Gift. (Triggert deine Gift-Synergien).
    // Original Kauf-Modifikator: +2 Giftresistenz, +1 Basis-Schaden.
    public NutrientSlime()
    {
        name = "Nutrient Slime";
        Symbol = "poison";
        Description = "self+5" + GameManager.Get("poison");
        Cost = "+2"+ GameManager.Get("vacine") +"+1" + GameManager.Get("damage");
    }

    public override void doCost(Wheel contex)
    {
        contex.vacine += 2;
        contex.damage += 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.poisen += 5;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}