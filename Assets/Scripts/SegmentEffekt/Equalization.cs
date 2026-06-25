using UnityEngine;

[Effect("Equalization")]
public class Equalization : WheelEffekt
{
    // Original Rad-Effekt: Setzt alle deine negativen permanenten Stats rein für diese Runde auf 0.
    // Original Kauf-Modifikator: +5 schwäche.
    public Equalization()
    {
        GameManager.Get("armor");
        name = "Equalization";
        Symbol = "bell";
        Description = GameManager.Get("weak") + "per self +1"+ GameManager.Get("poison")+" " + GameManager.Get("weak") + "=0";
    }

    public override void doCost(Wheel contex)
    {
        contex.weak += 5;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.poisen += contex.weak;
        contex.weak = 0;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}