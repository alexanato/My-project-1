using UnityEngine;

[Effect("CurseGlassFracture")]
public class CurseGlassFracture : WheelEffekt
{
    // Original Rad-Effekt: Fluch: Glasbruch Zerstört all deine Rüstung; du kannst in dieser Runde keine Rüstung mehr aufbauen.
    // Original Kauf-Modifikator: +5 Basis-Rüstung.
    public CurseGlassFracture()
    {
        name = "Glass Fracture";
        Symbol = "curse";
        Description = "-1"+ GameManager.Get("life") + "per"+ GameManager.Get("armor") +"and "+ "reset" + GameManager.Get("armor");
        Cost = "+5" + GameManager.Get("armor");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor += 5;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life -= contex.armor;
        contex.armor = 0;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}