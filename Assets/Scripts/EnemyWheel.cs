using TMPro;
using UnityEngine;

public class EnemyWheel : Wheel
{
    public TMP_Text texti;
    public TMP_Text textri;
    public TMP_Text textto;
    public TMP_Text textro;
    public TMP_Text textfi;

    private void Start()
    {
        wheel = false;
        GameManager.EnemyWheel = this;
        LoadEnemy(GameManager.stage);
        GameManager.ConnectWheels();
    }

    private new void Update()
    {
        base.Update();

        int outgoingDamage = Mathf.Max(0, TotalDamage * TotalTargets - weak);
        int playerOutgoingDamage = EnemyWheel == null
            ? 0
            : Mathf.Max(0, EnemyWheel.TotalDamage * EnemyWheel.TotalTargets - EnemyWheel.weak);

        if (texti != null)
        {
            texti.text = $"{GameManager.Get("damage")}{TotalDamage}x{GameManager.Get("target")}{TotalTargets}-{GameManager.Get("weak")}{weak}={outgoingDamage}";
        }

        if (textri != null)
        {
            textri.text = $"{GameManager.Get("poison")}{poisen}-{GameManager.Get("vacine")}{vacine}={GameManager.Get("poison")}{EffectivePoison}";
        }

        if (textto != null)
        {
            textto.text = $"{GameManager.Get("life")}{life}-{GameManager.Get("poison")}{EffectivePoison}={GameManager.Get("life")}{life - EffectivePoison}";
        }

        if (textro != null)
        {
            int resultLife = life - EffectivePoison - Mathf.Max(0, playerOutgoingDamage - TotalArmor);
            textro.text = $"{GameManager.Get("life")}{life - EffectivePoison}+{GameManager.Get("armor")}{TotalArmor}-{GameManager.Get("damage")}{playerOutgoingDamage}={GameManager.Get("life")}{resultLife}";
        }

        if (textfi != null)
        {
            textfi.text = $"{GameManager.Get("wheel")}{RemainingWheels}";
        }
    }
}
