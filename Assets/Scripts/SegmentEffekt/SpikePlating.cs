using UnityEngine;

[Effect("SpikePlating")]
public class SpikePlating : WheelEffekt
{
    // Original Rad-Effekt: Verursacht Damage in Höhe von 50% deiner aktuellen Rüstung.
    // Original Kauf-Modifikator: -2 Basis-Rüstung.
    public SpikePlating()
    {
        name = "Spike Plating";
        Symbol = "armor";
        Description = "if" + GameManager.Get("armor") + " = " + GameManager.Get("damage") +"+10"+ GameManager.Get("luck");
        Cost = "+2" + GameManager.Get("damage");
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage += 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        if(contex.damage == contex.armor)
        {
            contex.luck += 10;
        }
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}