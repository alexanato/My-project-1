using UnityEngine;

[Effect("RustyShield")]
public class RustyShield : WheelEffekt
{
    public RustyShield()
    {
        name = "Rusty Shield";
        Symbol = "broken";
        Description = "+7 " + GameManager.Get("armor") + " and +2 " + GameManager.Get("weak");
        Cost = "+1 base " + GameManager.Get("damage");
        type = EffektType.DEFENSE;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseDamage += 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.armor += 7;
                contex.weak += 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
