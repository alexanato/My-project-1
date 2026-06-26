using UnityEngine;

[Effect("SynergyScapegoat")]
public class SynergyScapegoat : WheelEffekt
{
    public SynergyScapegoat()
    {
        name = "Scapegoat";
        Symbol = "curse";
        Description = "+5 " + GameManager.Get("damage") + " per " + GameManager.Get("curse") + " (max 20), self gains half as " + GameManager.Get("weak");
        Cost = "-2 base " + GameManager.Get("damage");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        int curses = contex.getCurses();
                contex.damage += Mathf.Min(20, curses * 5);
                contex.weak += (curses + 1) / 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 2 && contex.getCurses() >= 1;
    }
}
