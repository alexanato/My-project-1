using UnityEngine;

[Effect("CurseToxicSource")]
public class CurseToxicSource : WheelEffekt
{
    // Original Rad-Effekt: Fluch: Toxische Quelle Du erhältst 15 Gift, der Gegner wird komplett von seinem Gift geheilt.
    // Original Kauf-Modifikator: +5 Giftresistenz, +15 Glück.
    public CurseToxicSource()
    {
        name = "Toxic Source";
        Symbol = "curse";
        Description = "+15 " + GameManager.Get("poison") + "enemy reset" + GameManager.Get("poison");
        Cost = "+5" + GameManager.Get("vacine") + "15" + GameManager.Get("luck");
    }

    public override void doCost(Wheel contex)
    {
        contex.vacine += 5;
        contex.luck += 15;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.poisen += 15;
        contex.EnemyWheel.poisen = 0;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}