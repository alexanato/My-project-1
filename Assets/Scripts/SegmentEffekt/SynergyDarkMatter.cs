using UnityEngine;

[Effect("SynergyDarkMatter")]
public class SynergyDarkMatter : WheelEffekt
{
    public SynergyDarkMatter()
    {
        name = "Dark Matter";
        Symbol = "curse";
        Description = "+1 " + GameManager.Get("target") + " per 2 " + GameManager.Get("curse") + " (max 2)";
        Cost = "-1 base " + GameManager.Get("target");
        type = EffektType.TARGET;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        int bonus = Mathf.Min(2, (contex.getCurses() + 1) / 2);
                contex.target += bonus;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2 && contex.getCurses() >= 1;
    }
}
