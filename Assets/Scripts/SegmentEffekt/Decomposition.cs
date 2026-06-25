using UnityEngine;

[Effect("Decomposition")]
public class Decomposition : WheelEffekt
{
    // Original Rad-Effekt: Gegner verliert 1 Basis-Rüstung (für diesen Kampf) pro 3 Gift-Stapel, die er hat.
    // Original Kauf-Modifikator: -1 Basis-Mehrfachtreffer.
    public Decomposition()
    {
        name = "Decomposition";
        Symbol = "broken";
        Description = "-5" + GameManager.Get("life") + "enemy x1.5" + GameManager.Get("poison");
        Cost = "-1" + GameManager.Get("target");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life -= 1;
        contex.EnemyWheel.poisen *= (int)1.5;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}