using UnityEngine;

[Effect("ArmorBreak")]
public class ArmorBreak : WheelEffekt
{
    // Original Rad-Effekt: Zerstört 10 Armor beim Gegner und fügt ihm +3 Schwäche zu.
    // Original Kauf-Modifikator: -1 Basis-Rüstung.
    public ArmorBreak()
    {
        name = "Armor Break";
        Symbol = "broken";
        Description = "enemy -10" + GameManager.Get("armor") + "+3 " + GameManager.Get("broken");
        type = EffektType.DEFENSE;
        Cost = "-1" + GameManager.Get("armor");
    }

    public override void doCost(Wheel contex)
    {
        contex.armor -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.EnemyWheel.armor =  Mathf.Max(0, contex.EnemyWheel.armor - 10);
        contex.EnemyWheel.weak += 3;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 1;
    }
}