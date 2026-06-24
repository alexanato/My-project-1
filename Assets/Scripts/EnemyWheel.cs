using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class EnemyWheel : Wheel
{
    public TMP_Text texti;
    public TMP_Text textri;
    public TMP_Text textto;
    public TMP_Text textro;
    public TMP_Text textfi;
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
    private void Update()
    {
        base.Update();
        texti.text = $"{GameManager.Get("damage")}{baseDamage + damage}x{GameManager.Get("target")}{baseTarget + target}-{GameManager.Get("weak")}{weak}={Math.Max(0, (baseDamage + damage) * (baseTarget + target) - weak)}";
        textri.text = $"{GameManager.Get("poison")}{poisen}-{GameManager.Get("vacine")}{vacine}={GameManager.Get("poison")}{math.max(0, poisen - vacine)}";
        textto.text = $"{GameManager.Get("life")}{life}-{GameManager.Get("poison")}{poisen}={GameManager.Get("life")}{life - poisen}";
        textro.text = $"{GameManager.Get("life")}{life - poisen}+{GameManager.Get("armor")}{armor + baseArmor}- {GameManager.Get("damage")}{EnemyWheel.damage + EnemyWheel.baseDamage}={GameManager.Get("life")}{(life - poisen) - Math.Max((EnemyWheel.damage + EnemyWheel.baseDamage) - (armor + baseArmor), 0)}";
        textfi.text = $"{GameManager.Get("wheel")}{((wheelCount+baseWheelCount)*2-x)}";
    }
}
