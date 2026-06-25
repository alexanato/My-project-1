using UnityEngine;

[Effect("PrecisionStrike")]
public class PrecisionStrike : WheelEffekt
{
    // Original Rad-Effekt: Dieser Angriff ignoriert den Schwäche-Abzug bei der Schadensberechnung komplett.
    // Original Kauf-Modifikator: -2 Glück.
    public PrecisionStrike()
    {
        name = "Precision Strike";
        Symbol = "target";
        Description = "+1" + GameManager.Get("damage") +"this damage incemety by 1";
        Cost = "+10" + GameManager.Get("weak");
    }

    public override void doCost(Wheel contex)
    {
        contex.weak += 10;
    }
    private int x = 1;

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += x;
        x++;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}