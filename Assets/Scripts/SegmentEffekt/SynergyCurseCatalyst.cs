using UnityEngine;

[Effect("SynergyCurseCatalyst")]
public class SynergyCurseCatalyst : WheelEffekt
{
    // Original Rad-Effekt: Synergie: Fluch-Katalysator Verdoppelt Effekte aller anderen Segmente, fügt deinem Rad für diesen Kampf aber ein zufälliges verfluchtes Segment hinzu.
    // Original Kauf-Modifikator: -15 Glück.
    public SynergyCurseCatalyst()
    {
        name = "Curse Catalyst";
        Symbol = "curse";
        Description = "2x" + GameManager.Get("damage") +"if" + GameManager.Get("life") + "= <10";
        Cost = "-10" + GameManager.Get("life");
    }

    public override void doCost(Wheel contex)
    {
        contex.life -= 10;
    }

    public override void DoEffekt(Wheel contex)
    {
        if (contex.life > 10) return; 
        contex.damage *= 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}