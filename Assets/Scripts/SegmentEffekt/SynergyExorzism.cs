using UnityEngine;

[Effect("SynergyExorzism")]
public class SynergyExorzism : WheelEffekt
{
    // Original Rad-Effekt: Synergie: Exorzismus Verursacht 5 Damage. Darfst ein verfluchtes Segment für diesen Kampf deaktivieren (wird zum leeren Feld).
    // Original Kauf-Modifikator: -2 Basis-Rüstung.
    public SynergyExorzism()
    {
        name = "Exorcism";
        Symbol = "bell";
        Description = "+1" +GameManager.Get("luck") +"per"+GameManager.Get("curse");
        Cost = ">3" + GameManager.Get("curse") + " amount";
    }

    public override void doCost(Wheel contex)
    {
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.luck += contex.getCurses();
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.getCurses() >= 3;
    }
}