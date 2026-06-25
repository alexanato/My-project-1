using UnityEngine;

[Effect("VengeanceStrike")]
public class VengeanceStrike : WheelEffekt
{
    // Original Rad-Effekt: Verursacht Damage = (Erlittener HP-Schaden der letzten Runde × 2).
    // Original Kauf-Modifikator: -2 Basis-Rüstung.
    public VengeanceStrike()
    {
        name = "Vengeance Strike";
        Symbol = "sword";
        Description = "(100- current" + GameManager.Get("life") +")/5";
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += (100 - Mathf.Min(contex.life, 100)) / 5;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 3;
    }
}