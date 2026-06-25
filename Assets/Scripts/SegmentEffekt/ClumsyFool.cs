using UnityEngine;

[Effect("ClumsyFool")]
public class ClumsyFool : WheelEffekt
{
    // Original Rad-Effekt: Du erhältst 3 Gift, 3 Schwäche, -5 Armor. Fügt dem Gegner keinen Schaden zu.
    // Original Kauf-Modifikator: +3 Basis-Schaden, +3 Basis-Rüstung, +20 Glück.
    public ClumsyFool()
    {
        name = "Clumsy Fool";
        Symbol = "broken";
        Description = "-10" + GameManager.Get("broken");
        Cost = "+10"+ GameManager.Get("luck");
    }

    public override void doCost(Wheel contex)
    {
        contex.luck += 10;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.weak += 10;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}