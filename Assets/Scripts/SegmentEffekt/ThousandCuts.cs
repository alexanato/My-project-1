using UnityEngine;

[Effect("ThousandCuts")]
public class ThousandCuts : WheelEffekt
{
    // Original Rad-Effekt: +5 Mehrfachtreffer, aber -5 Damage für diesen Dreh.
    // Original Kauf-Modifikator: +2 Basis-Schaden.
    public ThousandCuts()
    {
        name = "Thousand Cuts";
        Symbol = "sword";
        Description = "+5"+ GameManager.Get("target") +"-20" + GameManager.Get("damage");
        Cost = "-1" + GameManager.Get("target");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        if(contex.damage >= 20)
        {
            contex.damage -= 20;
            contex.target += 5;
        }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}