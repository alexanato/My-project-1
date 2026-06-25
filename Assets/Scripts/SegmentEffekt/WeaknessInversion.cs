using UnityEngine;

[Effect("WeaknessInversion")]
public class WeaknessInversion : WheelEffekt
{
    // Original Rad-Effekt: Wandelt 50% deiner aktuellen Schwäche in Mehrfachtreffer für diesen Dreh um.
    // Original Kauf-Modifikator: -1 Basis-Schaden.
    public WeaknessInversion()
    {
        name = "Weakness Inversion";
        Symbol = "sword";
        Description ="per 2" +GameManager.Get("broken") + "+1" + GameManager.Get("target");
        Cost = "-5" + GameManager.Get("luck");
    }

    public override void doCost(Wheel contex)
    {
        contex.luck -= 5;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.target += contex.weak / 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 5;
    }
}