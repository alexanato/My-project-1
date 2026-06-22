using UnityEngine;

public class EnemyWheel : Wheel
{
    void Start()
    {
        GameManager.EnemyWheel = this;
        Effekts[0] = new DamageEffekt();
        Effekts[1] = new DamageEffekt();
        Effekts[2] = new DamageEffekt();
        Effekts[3] = new DamageEffekt();
        Effekts[4] = new DamageEffekt(43);
        Effekts[5] = new DamageEffekt();
        Effekts[6] = new DamageEffekt();
        Effekts[7] = new DamageEffekt();
    }
}
