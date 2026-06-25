using UnityEngine;

[Effect("WeaknessCascade")]
public class WeaknessCascade : WheelEffekt
{
    // Original Rad-Effekt: Verursacht Damage = (Eigene Schwäche × Gegner Schwäche).
    // Original Kauf-Modifikator: +2 Schwäche.
    public WeaknessCascade()
    {
        name = "Weakness Cascade";
        Symbol = "target";
        Description = "+1" + GameManager.Get("damage") +"per enemy" + GameManager.Get("broken");
        Cost = "-1" + GameManager.Get("target");
    }

    public override void doCost(Wheel contex)
    {
        contex.target -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += contex.EnemyWheel.weak;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.target >= 2;
    }
}