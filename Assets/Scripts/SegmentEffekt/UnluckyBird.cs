using UnityEngine;

[Effect("UnluckyBird")]
public class UnluckyBird : WheelEffekt
{
    // Original Rad-Effekt: Verursacht 4 Damage pro negativem permanenten Stat auf deinem Charakterbogen.
    // Original Kauf-Modifikator: +10 Glück.
    public UnluckyBird()
    {
        name = "Unlucky Bird";
        Symbol = "broken";
        Description = "-1" + GameManager.Get("life");
        Cost = "+10" + GameManager.Get("luck");
    }

    public override void doCost(Wheel contex)
    {
        contex.luck += 10;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life -= 1;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}