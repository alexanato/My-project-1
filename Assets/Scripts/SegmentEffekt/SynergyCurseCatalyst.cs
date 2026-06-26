using UnityEngine;

[Effect("SynergyCurseCatalyst")]
public class SynergyCurseCatalyst : WheelEffekt
{
    public SynergyCurseCatalyst()
    {
        name = "Curse Catalyst";
        Symbol = "curse";
        Description = "+6 " + GameManager.Get("damage") + " per " + GameManager.Get("curse") + " (max 18); no curse: +4";
        Cost = "-8 " + GameManager.Get("life");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.life -= 8;
    }

    public override void DoEffekt(Wheel contex)
    {
        int curses = contex.getCurses();
                contex.damage += curses == 0 ? 4 : Mathf.Min(18, curses * 6);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.life > 8;
    }
}
