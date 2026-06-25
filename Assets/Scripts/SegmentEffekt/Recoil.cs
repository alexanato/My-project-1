using UnityEngine;

[Effect("Recoil")]
public class Recoil : WheelEffekt
{
    // Original Rad-Effekt: +1 Wheel, aber -2 Damage für diesen spezifischen Dreh.
    // Original Kauf-Modifikator: +2 Basis-Schaden.
    public Recoil()
    {
        name = "Recoil";
        Symbol = "broken";
        Description = "+1 " + GameManager.Get("wheel");
        Cost = "+10" + GameManager.Get("luck");
    }

    public override void doCost(Wheel contex)
    {
        contex.luck += 10;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.wheelCount++;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}