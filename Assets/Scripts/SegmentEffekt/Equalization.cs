using UnityEngine;

[Effect("Equalization")]
public class Equalization : WheelEffekt
{
    public Equalization()
    {
        name = "Equalization";
        Symbol = "bell";
        Description = "Convert up to 5 " + GameManager.Get("weak") + " into " + GameManager.Get("armor") + "; gain half as " + GameManager.Get("poison");
        Cost = "-1 " + GameManager.Get("vacine");
        type = EffektType.UTILITY;
    }

    public override void doCost(Wheel contex)
    {
        contex.vacine -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        int amount = Mathf.Min(5, contex.weak);
                contex.weak -= amount;
                contex.armor += amount * 2;
                contex.poisen += Mathf.CeilToInt(amount / 2f);
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.vacine >= 1;
    }
}
