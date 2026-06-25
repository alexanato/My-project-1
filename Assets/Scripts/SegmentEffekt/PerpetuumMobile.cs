using UnityEngine;

[Effect("PerpetuumMobile")]
public class PerpetuumMobile : WheelEffekt
{
    // Original Rad-Effekt: +1 Wheel, falls deine aktuelle Rüstung exakt 0 beträgt.
    // Original Kauf-Modifikator: -1 Basis-Rüstung.
    public PerpetuumMobile()
    {
        name = "Perpetuum Mobile";
        Symbol = "wheel";
        Description = "+2 " + GameManager.Get("wheel") + " if " + GameManager.Get("armor") + " = 0 +1"+ GameManager.Get("armor");
        Cost = "+10" + GameManager.Get("poison");
    }

    public override void doCost(Wheel contex)
    {
        contex.poisen += 10;
    }

    public override void DoEffekt(Wheel contex)
    {
        if(contex.armor == 0)
        {
            contex.wheelCount++;
            contex.wheelCount++;
            contex.armor++;
        }
        
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}