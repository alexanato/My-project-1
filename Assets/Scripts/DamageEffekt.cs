public class DamageEffekt : WheelEffekt
{
    private readonly int amount;

    public DamageEffekt(int amount = 2)
    {
        this.amount = amount;
        Description = "+" + amount + " " + GameManager.Get("damage");
        Cost = "";
        name = "Weak Hit";
        Symbol = "sword";
        type = EffektType.ATTACK;
    }

    public override void doCost(Wheel contex)
    {
    }

    public override void DoEffekt(Wheel contex)
    {
        contex.damage += amount;
    }

    public override bool haveCost(Wheel contex)
    {
        return true;
    }
}
