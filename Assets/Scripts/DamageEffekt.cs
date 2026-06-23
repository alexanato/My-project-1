using UnityEngine;

public class DamageEffekt :WheelEffekt
{
    int a = 2;
    public DamageEffekt(int a = 2)
    {
        Description = "+"+ a +GameManager.Get("damage");
        this.a = a;
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
}
