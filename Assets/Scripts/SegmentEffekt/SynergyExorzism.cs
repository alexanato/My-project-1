using UnityEngine;

[Effect("SynergyExorzism")]
public class SynergyExorzism : WheelEffekt
{
    public SynergyExorzism()
    {
        name = "Exorcism";
        Symbol = "bell";
        Description = "Per " + GameManager.Get("curse") + ": remove 2 " + GameManager.Get("poison") + " and 1 " + GameManager.Get("weak");
        Cost = "-5 " + GameManager.Get("luck");
        type = EffektType.UTILITY;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddLuck(-5);
    }

    public override void DoEffekt(Wheel contex)
    {
        int curses = contex.getCurses();
                contex.poisen = Mathf.Max(0, contex.poisen - curses * 2);
                contex.weak = Mathf.Max(0, contex.weak - curses);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 5 && contex.getCurses() >= 2;
    }
}
