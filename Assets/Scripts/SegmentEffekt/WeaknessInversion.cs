using UnityEngine;

[Effect("WeaknessInversion")]
public class WeaknessInversion : WheelEffekt
{
    public WeaknessInversion()
    {
        name = "Weakness Inversion";
        Symbol = "sword";
        Description = "Convert up to 6 " + GameManager.Get("weak") + " into +1 " + GameManager.Get("target") + " per 2";
        Cost = "-5 " + GameManager.Get("luck");
        type = EffektType.TARGET;
    }

    public override void doCost(Wheel contex)
    {
        contex.AddLuck(-5);
    }

    public override void DoEffekt(Wheel contex)
    {
        int pairs = Mathf.Min(3, contex.weak / 2);
                contex.weak -= pairs * 2;
                contex.target += pairs;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.luck >= 5;
    }
}
