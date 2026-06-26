using UnityEngine;

[Effect("Karma")]
public class Karma : WheelEffekt
{
    public Karma()
    {
        name = "Karma";
        Symbol = "life";
        Description = "Heal from your debuffs: " + GameManager.Get("weak") + " + half " + GameManager.Get("poison") + " (max 8)";
        Cost = "-2 base " + GameManager.Get("armor");
        type = EffektType.LIFE;
    }

    public override void doCost(Wheel contex)
    {
        contex.baseArmor -= 2;
    }

    public override void DoEffekt(Wheel contex)
    {
        int healing = Mathf.Min(8, contex.weak + contex.poisen / 2);
                contex.Heal(healing);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseArmor >= 2;
    }
}
