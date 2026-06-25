using UnityEngine;

[Effect("CurseRigorMortis")]
public class CurseRigorMortis : WheelEffekt
{
    // Original Rad-Effekt: Fluch: Totenstarre Beendet deine Runde sofort. Du verlierst alle verbleibenden Wheels für diese Runde.
    // Original Kauf-Modifikator: +3 Mehrfachtreffer.
    public CurseRigorMortis()
    {
        name = "Rigor Mortis";
        Symbol = "curse";
        Description = "End turn";
        Cost = "+3" + GameManager.Get("target");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget += 3;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.x = (contex.baseWheelCount + contex.wheelCount) * 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}