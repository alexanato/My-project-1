using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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
    [SerializeField] public Vector2 rotRange = new Vector2 (90,180);
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
    public TMP_Text SpecialLuckText;
    public TMP_Text stageText;
    public Animator lucki;
    public Wheel EnemyWheel;
    private bool drag;
    private bool spinni;
    public EffektType type;
    public GameObject Shopppp;
    public GameObject IEEE;
    public GameObject IE;
    public bool aa;
    // wheel = true = Player
    // wheel = false = Enemy
    public bool wheel;
    public void Update()
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
        if (stageText != null) stageText.text = GameManager.stage + "/30";
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
        if ( GameManager.currentPhase == 1)
        {
            Shopppp.SetActive(false);
            IEEE.SetActive(true);
            IE.SetActive(true);
            GameManager.currentPhase = 0;
            yield break;
        }
        y= true;
        if (EnemyWheel.x == (EnemyWheel.baseWheelCount + EnemyWheel.wheelCount) * 2)
        {
            GameManager.currentWheel = true;
            if(UnityEngine.Random.Range(0, 100) <= EnemyWheel.luck)
            {
                SpecialLuckText.gameObject.SetActive(true);
                switch(UnityEngine.Random.Range(0, 10))
                {
                    case 0:
                        SpecialLuckText.text = "2x" + GameManager.Get("damage");
                        EnemyWheel.damage *= 2;
                        lucki.SetBool("doit", true);
                        yield return new WaitForSeconds(0.1f);
                        lucki.SetBool("doit", false);
                        yield return new WaitUntil(() => !lucki.GetComponent<LuckText>().doit);
                        break;
                    case 1:
                        SpecialLuckText.text = "+1" + GameManager.Get("damage");
                        EnemyWheel.baseDamage += 1;
                        lucki.SetBool("doit", true);
                        yield return new WaitForSeconds(0.1f);
                        lucki.SetBool("doit", false);
                        yield return new WaitUntil(() => !lucki.GetComponent<LuckText>().doit);
                        break;
                    case 2:
                        SpecialLuckText.text = "2x" + GameManager.Get("armor");
                        EnemyWheel.armor *= 2;
                        lucki.SetBool("doit", true);
                        yield return new WaitForSeconds(0.1f);
                        lucki.SetBool("doit", false);
                        yield return new WaitUntil(() => !lucki.GetComponent<LuckText>().doit);
                        break;
                    case 3:
                        SpecialLuckText.text = "+1" + GameManager.Get("armor");
                        EnemyWheel.baseArmor +=1;
                        lucki.SetBool("doit", true);
                        yield return new WaitForSeconds(0.1f);
                        lucki.SetBool("doit", false);
                        yield return new WaitUntil(() => !lucki.GetComponent<LuckText>().doit);
                        break;
                    case 4:
                        SpecialLuckText.text = "+1" + GameManager.Get("vacine");
                        EnemyWheel.vacine += 1;
                        lucki.SetBool("doit", true);
                        yield return new WaitForSeconds(0.1f);
                        lucki.SetBool("doit", false);
                        yield return new WaitUntil(() => !lucki.GetComponent<LuckText>().doit);
                        break;
                    case 5:
                        SpecialLuckText.text = "1/2" + GameManager.Get("poison");
                        EnemyWheel.poisen /= 2;
                        lucki.SetBool("doit", true);
                        yield return new WaitForSeconds(0.1f);
                        lucki.SetBool("doit", false);
                        yield return new WaitUntil(() => !lucki.GetComponent<LuckText>().doit);
                        break;
                    case 6:
                        SpecialLuckText.text = "+5" + GameManager.Get("life");
                        EnemyWheel.life += 5;
                        lucki.SetBool("doit", true);
                        yield return new WaitForSeconds(0.1f);
                        lucki.SetBool("doit", false);
                        yield return new WaitUntil(() => !lucki.GetComponent<LuckText>().doit);
                        break;
                    case 8:
                        SpecialLuckText.text = "-2" + GameManager.Get("broken");
                        EnemyWheel.weak -= Math.Max(2, 0);
                        EnemyWheel.weak = Math.Max(EnemyWheel.weak, 0);
                        lucki.SetBool("doit", true);
                        yield return new WaitForSeconds(0.1f);
                        lucki.SetBool("doit", false);
                        yield return new WaitUntil(() => !lucki.GetComponent<LuckText>().doit);
                        break;
                    case 9:
                        SpecialLuckText.text = "+5" + GameManager.Get("luck");
                        EnemyWheel.luck += 5;
                        lucki.SetBool("doit", true);
                        yield return new WaitForSeconds(0.1f);
                        lucki.SetBool("doit", false);
                        yield return new WaitUntil(() => !lucki.GetComponent<LuckText>().doit);
                        break;

                }
                SpecialLuckText.gameObject.SetActive(false);
            }


            yield return new WaitForSeconds(1);
            EnemyWheel.apply();
            apply();
            reset();
            EnemyWheel.reset();
            if(life <= 0)
            {
                Shopppp.SetActive(true);
                IEEE.SetActive(false);
                IE.SetActive(false);
                Shopppp.GetComponent<ShopManager>().lastPhase = 0;
                GameManager.stage++;
                GameManager.currentPhase = 1;
            }
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
                yield return new WaitUntil(()=>Math.Max(currentRot,0)==0);
                execute();
            }
            GameManager.currentWheel = false;
        }
        y= false;
    }
    private void reset()
    {
      damage = 0;
      armor = 0;
        poisen = Math.Max(0,poisen-vacine);
      target = 0;
      wheelCount = 0;
    }
    public int x = 0;
    private bool h = true;
    public void doPlayer()
    {
        if (wheel && !GameManager.currentWheel && h && GameManager.currentPhase == 1)
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
        life -= poisen;
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
            h= false;
            drag = true;
            spinni = true;
        }
    }
    public void execute()
    {
        h = true;
        Effekts[getCurrentColor()].DoEffekt(this);
        type = Effekts[getCurrentColor()].type;
    }
    public int getCurrentColor()
    {
         return((int)( (transform.eulerAngles.z) / 45) + startOffset)%8;
    }
    public int getCurses()
    {
        int y = 0;
        for(int i = 0; i < 8; i++) 
        {
            if (Effekts[i].Symbol.Equals("curse")) y++;
        }
        return y;
    }
}
