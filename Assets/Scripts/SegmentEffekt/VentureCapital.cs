using UnityEngine;

[Effect("VentureCapital")]
public class VentureCapital : WheelEffekt
{
    // Original Rad-Effekt: Risiko-Kapital +5 Damage pro 10 fehlende Lebenspunkte bei dir selbst.
    // Original Kauf-Modifikator: -3 Basis-Rüstung, -10 Glück.
    public VentureCapital()
    {
        name = "Venture Capital";
        Symbol = "none";
        Description = ""+GameManager.Get("life") +"=1 +20" + GameManager.Get("damage");
        Cost = "+15" + GameManager.Get("life");
    }

    public override void doCost(Wheel contex)
    {
        contex.life += 15;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life = 1;
        contex.damage += 20;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}