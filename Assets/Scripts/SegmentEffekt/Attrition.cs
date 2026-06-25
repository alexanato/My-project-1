using UnityEngine;

[Effect("Attrition")]
public class Attrition : WheelEffekt
{
    // Original Rad-Effekt: +3 Schwäche beim Gegner.
    // Original Kauf-Modifikator: -2 Glück.
    public Attrition()
    {
        name = "Attrition";
        Symbol = "target";
        Description = "enemy +3" + GameManager.Get("broken");
        Cost = "-2"+GameManager.Get("luck");
    }

    public override void doCost(Wheel contex)
    {
        contex.luck -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.EnemyWheel.weak += 3;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 2;
    }
}