using UnityEngine;

public class DamageEffekt :WheelEffekt
{
    int a = 2;
    public DamageEffekt(int a = 2)
    {
        Description = "+"+ a +GameManager.Get("damage");
        this.a = a;
        name = "weak Hit";
        Symbol = "sword";
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += a;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
