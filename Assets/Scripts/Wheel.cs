using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    [Serializable]
    public struct SegmentEntry
    {
        public TMP_Text description;
        public Image symblol;
    }
    [SerializeField] private Vector2 rotRange = new Vector2 (90,180);
    [SerializeField] private float rotDrag = 3;
    private float currentRot;
    [SerializeField] int startOffset = 0;
    public WheelEffekt[] Effekts = new WheelEffekt[8];
    public List<SegmentEntry> segmentEntrys = new List<SegmentEntry>();
    public int life;
    public int luck;
    public int baseDamage;
    public int damage;
    public int armor;
    public int baseArmor;
    public int poisen;
    public int baseTarget;
    public int target;
    public int vacine;
    public int weak;
    public int baseWheelCount = 1;
    public int wheelCount = 0;
    public TMP_Text luckText;
    public TMP_Text lifeText;
    public TMP_Text damageText;
    public TMP_Text armorText;
    public TMP_Text poisenText;
    public TMP_Text targetText;
    public TMP_Text vacineText;
    public TMP_Text weakText;
    public TMP_Text poisonSummText;
    public TMP_Text damageSummText;
    public TMP_Text wheelText;
    public Wheel EnemyWheel;
    private bool drag;
    private bool spinni;
    private EffektType type;
    // wheel = true = Player
    // wheel = false = Enemy
    public bool wheel;
    void Update()
    {
        if(drag) currentRot = Math.Max(0, currentRot - rotDrag * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, currentRot));
        if (luckText != null) luckText.text = "" + luck;
        if (lifeText != null) lifeText.text = "" + life;
        if (damageText != null) damageText.text = "" + (damage +baseDamage);
        if (armorText != null) armorText.text = "" + (armor + baseArmor);
        if (poisenText != null) poisenText.text = "" + poisen;
        if (targetText != null) targetText.text = "" + (target+baseTarget);
        if (vacineText != null) vacineText.text = "" + vacine;
        if (weakText != null) weakText.text = "" + weak;
        if (wheelText != null) wheelText.text = "" + (baseWheelCount+wheelCount-(int)(x/2));
        if (damageSummText != null) damageSummText.text = "" + ((damage + baseDamage) * (target + baseTarget) - weak);
        if (poisonSummText != null) poisonSummText.text = "" + (life - (Math.Max(0, poisen - vacine)));
        for (int i = 0; i < segmentEntrys.Count; i++) 
        {
            segmentEntrys[i].description.text =  Effekts[i].Description;
            segmentEntrys[i].symblol.sprite = GameManager.sprites[Effekts[i].Symbol];
        }
        if(currentRot == 0&& spinni&&wheel)
        {
            execute();
            spinni = false;
        }
    }
    public void turni()
    {
        if(!y)StartCoroutine(doTurn());
    }
    private bool y= false;
    public IEnumerator doTurn()
    {
        y= true;
        if (EnemyWheel.x == (EnemyWheel.baseWheelCount + EnemyWheel.wheelCount) * 2)
        {
            GameManager.currentWheel = true;
            yield return new WaitForSeconds(1);
            EnemyWheel.apply();
            apply();
            reset();
            EnemyWheel.reset();
            x= 0;
            EnemyWheel.x = 0;
        }
        if (!wheel && GameManager.currentWheel)
        {
            for (int i = 0; i < baseWheelCount + wheelCount; i++)
            {
                spin();
                x++;
                yield return new WaitForSeconds(0.5f);
                spin();
                x++;
                yield return new WaitForSeconds(2.5f);
                execute();
            }
            GameManager.currentWheel = false;
        }
        y= false;
    }
    private void reset()
    {
      luck = 0;
      damage = 0;
      armor = 0;
      poisen = 0;
      target = 0;
      wheelCount = 0;
    }
    private int x = 0;
    public void doPlayer()
    {
        if (wheel && !GameManager.currentWheel)
        {
            if(x == (baseWheelCount + wheelCount) * 2)
            {
                return;
            }
            x += 1;
            spin();
        }
    }
    public void apply()
    {
        if(type == EffektType.ATTACK)
        {
            EnemyWheel.life = EnemyWheel.life + Math.Min(EnemyWheel.armor - ((damage + baseDamage) * (target + baseTarget) - weak),0);
        }
    }
    public void spin()
    {
        if(currentRot == 0)
        {
            currentRot = UnityEngine.Random.Range(rotRange.x, rotRange.y);
            drag = false;
        }
        else
        {
            drag = true;
            spinni = true;
        }
    }
    public void execute()
    {
        Effekts[getCurrentColor()].DoEffekt(this);
        type = Effekts[getCurrentColor()].type;
    }
    private int getCurrentColor()
    {
         return((int)( (transform.eulerAngles.z) / 45) + startOffset)%8;
    }
}
