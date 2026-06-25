using UnityEngine;

[Effect("SynergyDarkMatter")]
public class SynergyDarkMatter : WheelEffekt
{
    // Original Rad-Effekt: Synergie: Dunkle Materie +2 Mehrfachtreffer für jedes verfluchte Segment auf dem Rad.
    // Original Kauf-Modifikator: -2 Basis-Mehrfachtreffer.
    public SynergyDarkMatter()
    {
        name = "Dark Matter";
        Symbol = "curse";
        Description = "+2 "+ GameManager.Get("target") + "per" + GameManager.Get("curse");
        Cost = "-2" + GameManager.Get("target");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.baseTarget += 2 * contex.getCurses();
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}