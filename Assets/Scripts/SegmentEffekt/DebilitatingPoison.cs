using UnityEngine;

[Effect("DebilitatingPoison")]
public class DebilitatingPoison : WheelEffekt
{
    // Original Rad-Effekt: Wenn Gegner Gift besitzt, erhält er zusätzlich +2 Schwäche.
    // Original Kauf-Modifikator: -1 Basis-Rüstung.
    public DebilitatingPoison()
    {
        name = "Debilitating Poison";
        Symbol = "poison";
        Description = "If enemy" + GameManager.Get("poison") + "> 4 =+4" + GameManager.Get("broken") + "enemy";
        Cost = "-1" + GameManager.Get("armor");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        if(contex.EnemyWheel.poisen >= 4)
        {
            contex.weak += 4;
        }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 1;
    }
}