using UnityEngine;

[Effect("MiasmaCloud")]
public class MiasmaCloud : WheelEffekt
{
    public MiasmaCloud()
    {
        name = "Miasma Cloud";
        Symbol = "poison";
        Description = "Enemy +2 " + GameManager.Get("poison") + " +1 per 3 temporary " + GameManager.Get("armor") + " (max 8)";
        Cost = "-2 base " + GameManager.Get("armor");
        type = EffektType.POISON;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.EnemyWheel.poisen += Mathf.Min(8, 2 + contex.armor / 3);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 2;
    }
}
