using UnityEngine;

[Effect("CurseParasiticPact")]
public class CurseParasiticPact : WheelEffekt
{
    public CurseParasiticPact()
    {
        name = "Parasitic Pact";
        Symbol = "curse";
        Description = "Curse: lose 15% current " + GameManager.Get("life") + " (min 5)";
        Cost = "+2 base " + GameManager.Get("damage") + " and +8 " + GameManager.Get("luck");
        type = EffektType.CURSE;
    }

    public override bool CanBeTriggeredAsSecondary => false;

    public override void doCost(Wheel contex)
    {
        contex.baseDamage += 2;
                contex.AddLuck(8);
    }

    public override void DoEffekt(Wheel contex)
    {
        int loss = Mathf.Max(5, Mathf.CeilToInt(contex.life * 0.15f));
                contex.life = Mathf.Max(1, contex.life - loss);
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
