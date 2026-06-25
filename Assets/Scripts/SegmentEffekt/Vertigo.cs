using UnityEngine;

[Effect("Vertigo")]
public class Vertigo : WheelEffekt
{
    // Original Rad-Effekt: +2 Wheel, du erhältst +3 Schwäche.
    // Original Kauf-Modifikator: +2 Basis-Rüstung.
    public Vertigo()
    {
        name = "Vertigo";
        Symbol = "wheel";
        Description = "+2 " + GameManager.Get("wheel") + "+10 " + GameManager.Get("broken");
        Cost = "-2" +GameManager.Get("wheel");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseWheelCount -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.wheelCount += 2;
        contex.weak += 10;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseWheelCount >= 3;
    }
}