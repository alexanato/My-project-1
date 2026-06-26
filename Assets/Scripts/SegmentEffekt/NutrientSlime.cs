using UnityEngine;

[Effect("NutrientSlime")]
public class NutrientSlime : WheelEffekt
{
    public NutrientSlime()
    {
        name = "Nutrient Slime";
        Symbol = "poison";
        Description = "Self +4 " + GameManager.Get("poison") + " and +6 " + GameManager.Get("armor");
        Cost = "+1 " + GameManager.Get("vacine");
        type = EffektType.POISON;
    }

    public override void doCost(Wheel contex)
    {
        contex.vacine += 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.poisen += 4;
                contex.armor += 6;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
