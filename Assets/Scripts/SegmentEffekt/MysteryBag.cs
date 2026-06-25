using UnityEngine;

[Effect("MysteryBag")]
public class MysteryBag : WheelEffekt
{
    // Original Rad-Effekt: Löst einen zufälligen Effekt der 7 anderen Segmente auf deinem Rad aus.
    // Original Kauf-Modifikator: -5 Glück.
    public MysteryBag()
    {
        name = "Mystery Bag";
        Symbol = "bell";
        Description = "activate 2 random segments";
        Cost = "-1" + GameManager.Get("target");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.Effekts[Random.Range(0, 8)].DoEffekt(contex);
        contex.Effekts[Random.Range(0, 8)].DoEffekt(contex);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}