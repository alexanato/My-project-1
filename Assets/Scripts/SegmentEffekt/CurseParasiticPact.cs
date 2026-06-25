using UnityEngine;

[Effect("CurseParasiticPact")]
public class CurseParasiticPact : WheelEffekt
{
    // Original Rad-Effekt: Fluch: Parasitärer Pakt Du verlierst sofort 20% deiner aktuellen HP (nicht blockbar).
    // Original Kauf-Modifikator:+1 speed, +1 Basis-Wheel.
    public CurseParasiticPact()
    {
        name = "Parasitic Pakt";
        Symbol = "curse";
        Description = "-20 " + GameManager.Get("life");
        type = EffektType.CURSE;
        Cost = "+1 speed +1" + GameManager.Get("wheel");
    }

    public override void doCost(Wheel contex)
    {
        contex.rotRange.y += 1;
        contex.baseWheelCount += 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life -= 20;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}