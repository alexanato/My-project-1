using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerWheel : Wheel
{
    public TMP_Text texti;
    public TMP_Text textri;
    public TMP_Text textto;
    public TMP_Text textro;
    public TMP_Text textfi;

    public Image bab;
    public Button bbb;
    public TMP_Text tttt;
    private void Start()
    {
        wheel = true;
        GameManager.PlayerWheel = this;

        maxLife = 80;
        life = 80;
        baseDamage = 3;
        baseArmor = 3;
        baseTarget = 2;
        baseWheelCount = 2;
        luck = 10;
        vacine = 1;
        poisen = 0;
        weak = 0;
        rotRange = new Vector2(7f, 8f);

        Effekts[0] = new DamageEffekt(2);
        Effekts[1] = new DamageEffekt(2);
        Effekts[2] = new DamageEffekt(2);
        Effekts[3] = new DamageEffekt(2);
        Effekts[4] = new DamageEffekt(4);
        Effekts[5] = new DamageEffekt(2);
        Effekts[6] = new DamageEffekt(2);
        Effekts[7] = new DamageEffekt(2);

        StartCoroutine(StartFirstFight());
    }

    private IEnumerator StartFirstFight()
    {
        yield return new WaitUntil(() => GameManager.instance != null && GameManager.EnemyWheel != null);
        GameManager.ConnectWheels();
        turni();
    }

    private new void Update()
    {

        base.Update();
        if(GameManager.currentPhase == 1) { 
            bab.enabled = true;
            bbb.enabled = true;
            tttt.enabled = true;
        }
        else
        {
            bab.enabled = false;
            bbb.enabled = false;
            tttt.enabled = false;
        }
        weak = Mathf.Clamp(weak, 0, 10);
        int outgoingDamage = Mathf.Max(0, TotalDamage * TotalTargets - weak);
        int enemyOutgoingDamage = EnemyWheel == null
            ? 0
            : Mathf.Max(0, EnemyWheel.TotalDamage * EnemyWheel.TotalTargets - EnemyWheel.weak);

        if (texti != null)
        {
            texti.text = $"{GameManager.Get("damage")}{TotalDamage}x{GameManager.Get("target")}{TotalTargets}-{GameManager.Get("weak")}{weak}={outgoingDamage} total{GameManager.Get("damage")}";
        }

        if (textri != null)
        {
            textri.text = $"{GameManager.Get("poison")}{poisen}-{GameManager.Get("vacine")}{vacine}={GameManager.Get("poison")}{EffectivePoison}";
        }

        if (textto != null)
        {
            textto.text = $"{GameManager.Get("life")}{life}-{GameManager.Get("poison")}{EffectivePoison}={GameManager.Get("life")}{life - EffectivePoison} total{GameManager.Get("life")}";
        }

        if (textro != null)
        {
            int resultLife = life - EffectivePoison - Mathf.Max(0, enemyOutgoingDamage - TotalArmor);
            textro.text = $"{GameManager.Get("life")}{life - EffectivePoison}+{GameManager.Get("armor")}{TotalArmor}-{GameManager.Get("damage")}{enemyOutgoingDamage}={GameManager.Get("life")}{resultLife}";
        }

        if (textfi != null)
        {
            textfi.text = $"{GameManager.Get("luck")}{luck}";
        }
    }

    public void OnDeath()
    {
        SceneManager.LoadScene(3);
    }

    public void OnWin()
    {
        SceneManager.LoadScene(2);
    }
}
