using UnityEngine;

[Effect("MysteryBag")]
public class MysteryBag : WheelEffekt
{
    public MysteryBag()
    {
        name = "Mystery Bag";
        Symbol = "bell";
        Description = "Trigger one random non-curse segment";
        Cost = "-1 base " + GameManager.Get("target");
        type = EffektType.LUCK;
    }

    public override bool CanBeTriggeredAsSecondary => false;

    public override void doCost(Wheel contex)
    {
        contex.baseTarget -= 1;
    }

    public override void DoEffekt(Wheel contex)
    {
        int start = Random.Range(0, 8);
                for (int offset = 0; offset < 8; offset++)
                {
                    int index = (start + offset) % 8;
                    if (index == contex.getCurrentColor()) continue;
                    if (contex.TryTriggerSecondaryEffect(index)) break;
                }
    }

    public override bool haveCost(Wheel contex)
    {
        return contex.baseTarget >= 2;
    }
}
