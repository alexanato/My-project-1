using UnityEngine;

[Effect("ViralEruption")]
public class ViralEruption : WheelEffekt
{
    public ViralEruption()
    {
        name = "Viral Eruption";
        Symbol = "poison";
        Description = "Consume up to 10 self " + GameManager.Get("poison") + "; +2 " + GameManager.Get("damage") + " each";
        Cost = "-1 " + GameManager.Get("vacine");
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
        contex.vacine -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        int consumed = Mathf.Min(10, contex.poisen);
                contex.poisen -= consumed;
                contex.damage += consumed * 2;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.vacine >= 1;
    }
}
