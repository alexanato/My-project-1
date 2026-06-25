using UnityEngine;

[Effect("SynergyDefiance")]
public class SynergyDefiance : WheelEffekt
{
    // Original Rad-Effekt: Synergie: Trotz Landest du auf einem verfluchten Segment, wird dessen effekt auf den Gegner umgeleitet. (1-mal pro Runde).
    // Original Kauf-Modifikator: -3 Basis-Wheel.
    public SynergyDefiance()
    {
        name = "Defiance";
        Symbol = "bell";
        Description = "+1"+GameManager.Get("life") +"per"+ GameManager.Get("curse");
        Cost = "-1"+GameManager.Get("damage");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage--;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life += contex.getCurses();
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseDamage >=1;
    }
}