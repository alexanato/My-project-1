using UnityEngine;

[Effect("Painkiller")]
public class Painkiller : WheelEffekt
{
    // Original Rad-Effekt: Dein Gift heilt dich in dieser Runde, anstatt Schaden zuzufügen.
    // Original Kauf-Modifikator: -2 Basis-Rüstung, -1 Giftresistenz.
    public Painkiller()
    {
        name = "Painkiller";
        Symbol = "life";
        Description ="per"+ GameManager.Get("poison") + "+1" + GameManager.Get("life");
        Cost = "-1" + GameManager.Get("vacine");
    }

    public override void doCost(Wheel contex)
    {
        contex.vacine--;
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.life += contex.poisen;
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.vacine >= 1;
    }
}