using UnityEngine;

[Effect("Focus")]
public class Focus : WheelEffekt
{
    // Original Rad-Effekt: Das nächste Segment, das du in dieser Runde triffst, wird doppelt ausgeführt.
    // Original Kauf-Modifikator: -1 Basis-Wheel.
    public Focus()
    {
        name = "Focus";
        Symbol = "target";
        Description = "activate neighboring segments";
        Cost = "-1" + GameManager.Get("wheel");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseWheelCount -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.Effekts[(contex.getCurrentColor() + 1)%8].DoEffekt(contex);
        contex.type = contex.Effekts[(contex.getCurrentColor() + 1) % 8].type;

        contex.Effekts[(contex.getCurrentColor() - 1 + 8) % 8].DoEffekt(contex);
        contex.type = contex.Effekts[(contex.getCurrentColor() - 1 + 8) % 8].type;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseWheelCount >= 1;
    }
}