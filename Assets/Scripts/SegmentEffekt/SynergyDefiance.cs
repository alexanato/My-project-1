using UnityEngine;

[Effect("SynergyDefiance")]
public class SynergyDefiance : WheelEffekt
{
    public SynergyDefiance()
    {
        name = "Defiance";
        Symbol = "bell";
        Description = "Per " + GameManager.Get("curse") + ": +3 " + GameManager.Get("armor") + " and heal 1 (caps 12/4)";
        Cost = "-1 base " + GameManager.Get("damage");
        type = EffektType.DEFENSE;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        int curses = contex.getCurses();
                contex.armor += Mathf.Min(12, curses * 3);
                contex.Heal(Mathf.Min(4, curses));
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 1 && contex.getCurses() >= 1;
    }
}
