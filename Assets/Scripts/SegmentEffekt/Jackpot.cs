using UnityEngine;

[Effect("Jackpot")]
public class Jackpot : WheelEffekt
{
    // Original Rad-Effekt: Wenn du in einer Runde 3-mal auf genau diesem Segment landest, verliert der Gegner sofort 50% seiner maximalen HP.
    // Original Kauf-Modifikator: -2 Basis-Wheel, -15 Glück.
    public Jackpot()
    {
        name = "Jackpot";
        Symbol = "wheel";
        Description = "30% +3" + GameManager.Get("wheel");
        Cost = "-3" + GameManager.Get("armor");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 3;
    }

    public override void DoEffekt(Wheel contex)
    {
        int r = Random.Range(1, 10);
        if( r >= 2)
        {
            contex.wheelCount += 3;
        }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 3;
    }
}