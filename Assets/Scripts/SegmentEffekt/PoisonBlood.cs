using UnityEngine;

public class PoisonBlood:WheelEffekt
{
    public PoisonBlood()
    {
        name = "Poison Blood";
        Description = "+5" + GameManager.Get("poison") + "you +3" + GameManager.Get("poison");
        Cost = "+1" + GameManager.Get("vacine");
        Symbol = "poison";
    }
    public override void doCost(Wheel contex)
    {
        contex.vacine += 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.poisen += 3;
        contex.EnemyWheel.poisen += 5;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
