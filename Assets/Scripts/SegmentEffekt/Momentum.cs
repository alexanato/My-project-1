using UnityEngine;

[Effect("Momentum")]
public class Momentum : WheelEffekt
{
    // Original Rad-Effekt: +1 Wheel, falls du in dieser Runde bereits mehr als 3 Treffer erzielt hast.
    // Original Kauf-Modifikator: -2 Basis-Wheel.
    public Momentum()
    {
        name = "Momentum";
        Symbol = "wheel";
        Description = "+2 " + GameManager.Get("wheel") + " if 2nd spind";
        Cost = "-1" + GameManager.Get("target");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        if(contex.x == 4)
        {
            contex.wheelCount += 2;
        }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}