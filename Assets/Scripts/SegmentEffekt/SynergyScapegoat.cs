using UnityEngine;

[Effect("SynergyScapegoat")]
public class SynergyScapegoat : WheelEffekt
{
    // Original Rad-Effekt: Synergie: Der Sündenbock Verursacht 10 Damage für jedes verfluchte Segment, das sich aktuell auf deinem Rad befindet.
    // Original Kauf-Modifikator: -2 Basis-Schaden.
    public SynergyScapegoat()
    {
        name = "Scapegoat";
        Symbol = "curse";
        Description = "10 " + GameManager.Get("damage") + "per" + GameManager.Get("curse");
        Cost = "-3" + GameManager.Get("damage");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage -= 3;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += 10 * contex.getCurses();
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >= 3;
    }
}