using UnityEngine;

[Effect("Painkiller")]
public class Painkiller : WheelEffekt
{
    public Painkiller()
    {
        name = "Painkiller";
        Symbol = "life";
        Description = "Heal current " + GameManager.Get("poison") + " (max 8), then self +2 " + GameManager.Get("poison");
        Cost = "-1 " + GameManager.Get("vacine");
        type = EffektType.LIFE;
    }

    public override void doCost(Wheel contex)
    {
        contex.vacine -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.Heal(Mathf.Min(8, contex.poisen));
                contex.poisen += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.vacine >= 1;
    }
}
