using UnityEngine;

[Effect("ViralEruption")]
public class ViralEruption : WheelEffekt
{
    // Original Rad-Effekt: Verursacht Damage in Höhe deines aktuellen Gifts × 2. Entfernt danach dein Gift.
    // Original Kauf-Modifikator: -2 Basis-Rüstung.
    public ViralEruption()
    {
        name = "Viral Eruption";
        Symbol = "poison";
        Description = "per" + GameManager.Get("poison") + "+1"+ GameManager.Get("damage") + "reset" + GameManager.Get("poison");
        Cost = "-10" + GameManager.Get("poison") +"4" + GameManager.Get("vacine");
    }

    public override void doCost(Wheel contex)
    {
        contex.poisen -= 10;
        contex.vacine += 4;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += contex.poisen;
        contex.poisen = 0;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.poisen >= 10;
    }
}