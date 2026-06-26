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

    [SerializeField] public Vector2 rotRange = new Vector2(7f, 8f);
    [SerializeField] private float rotDrag = 3f;
    private float currentRot;
    [SerializeField] public int startOffset = 0;
    [SerializeField] private int maxBonusWheelCount = 2;
    [SerializeField] private float minimumWheelSpeed = 3f;
    [SerializeField] private float maximumWheelSpeed = 13f;

    public WheelEffekt[] Effekts = new WheelEffekt[8];
    public List<SegmentEntry> segmentEntrys = new List<SegmentEntry>();
    public int maxLife = 80;
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
    public EffektType type = EffektType.UTILITY;
    public GameObject Shopppp;
    public GameObject IEEE;
    public GameObject IE;
    public bool aa;

    // wheel = true = Player
    // wheel = false = Enemy
    public bool wheel;

    private bool y = false;
    private bool h = true;
    private bool roundResolutionRunning = false;
    private bool battleFinished = false;
    private bool firstFightStarted = false;
    private int secondaryEffectDepth = 0;
    public int x = 0;
    public AudioSource audioSource;
    public int TotalDamage => Mathf.Max(0, baseDamage + damage);
    public int TotalArmor => Mathf.Max(0, baseArmor + armor);
    public int TotalTargets => Mathf.Max(1, baseTarget + target);
    public int EffectivePoison => Mathf.Max(0, poisen - vacine);
    public int RemainingWheels => Mathf.Max(0, baseWheelCount + wheelCount - x / 2);
    private int z = 0;

    public void Update()
    {
        if( z != getCurrentColor())
        {
            print(segmentEntrys[z].description.text);
            audioSource.pitch = 1 + UnityEngine.Random.Range(-0.1f,0.1f);
            audioSource.Play();
            z = getCurrentColor();
        }
        if (drag)
        {
            currentRot = Mathf.Max(0f, currentRot - rotDrag * Time.deltaTime);
        }

        transform.Rotate(new Vector3(0f, 0f, currentRot));

        if (luckText != null) luckText.text = luck.ToString();
        if (lifeText != null) lifeText.text = life.ToString();
        if (damageText != null) damageText.text = TotalDamage.ToString();
        if (armorText != null) armorText.text = TotalArmor.ToString();
        if (poisenText != null) poisenText.text = poisen.ToString();
        if (targetText != null) targetText.text = TotalTargets.ToString();
        if (vacineText != null) vacineText.text = vacine.ToString();
        if (weakText != null) weakText.text = weak.ToString();
        if (wheelText != null) wheelText.text = RemainingWheels.ToString();
        if (damageSummText != null) damageSummText.text = Mathf.Max(0, TotalDamage * TotalTargets - weak).ToString();
        if (poisonSummText != null) poisonSummText.text = (life - EffectivePoison).ToString();
        if (stageText != null) stageText.text = GameManager.stage + "/30";

        int segmentCount = Mathf.Min(segmentEntrys.Count, Effekts.Length);
        for (int i = 0; i < segmentCount; i++)
        {
            if (Effekts[i] == null) continue;

            if (segmentEntrys[i].description != null)
            {
                segmentEntrys[i].description.text = Effekts[i].Description;
            }

            if (segmentEntrys[i].symblol != null &&
                GameManager.sprites.TryGetValue(Effekts[i].Symbol, out Sprite sprite))
            {
                segmentEntrys[i].symblol.sprite = sprite;
            }
        }

        // Nur das Spielerrad wird per Klick gestoppt. Der Gegner wird in doTurn()
        // automatisch gedreht und dort direkt ausgeführt.
        if (currentRot <= 0f && spinni && wheel)
        {
            spinni = false;
            drag = false;
            execute();

            if (GameManager.currentPhase == 0 &&
                GameManager.currentWheel &&
                !roundResolutionRunning &&
                x >= (baseWheelCount + wheelCount) * 2)
            {
                StartCoroutine(ResolveRoundAfterPlayer());
            }
        }
    }

    public void turni()
    {
        // Falls der Button aus Versehen am EnemyWheel hängt, wird trotzdem
        // das Spielerrad verwendet. Die öffentliche Struktur bleibt gleich.
        if (!wheel)
        {
            if (GameManager.PlayerWheel != null)
            {
                GameManager.PlayerWheel.turni();
            }
            return;
        }

        bool startsFirstFight = !firstFightStarted &&
                                GameManager.stage == 1 &&
                                GameManager.currentPhase == 0 &&
                                !GameManager.currentWheel;

        if (!y && !battleFinished &&
            (GameManager.currentPhase == 1 || startsFirstFight))
        {
            StartCoroutine(doTurn());
        }
    }

    public IEnumerator doTurn()
    {
        if (!wheel || y || battleFinished) yield break;

        y = true;
        firstFightStarted = true;
        GameManager.ConnectWheels();
        EnemyWheel = GameManager.EnemyWheel;

        if (EnemyWheel == null)
        {
            Debug.LogError("EnemyWheel wurde nicht gefunden.");
            y = false;
            yield break;
        }

        if (Shopppp != null) Shopppp.SetActive(false);
        if (IEEE != null) IEEE.SetActive(true);
        if (IE != null) IE.SetActive(true);

        GameManager.currentPhase = 0;
        GameManager.currentWheel = false;

        x = 0;
        wheelCount = 0;
        EnemyWheel.x = 0;
        EnemyWheel.wheelCount = 0;

        // Der Gegner beginnt immer. Erst wenn alle gegnerischen Drehungen
        // abgeschlossen sind, darf der Spieler reagieren.
        yield return StartCoroutine(ApplyLuckEffect(EnemyWheel));
        yield return StartCoroutine(RunEnemyTurn());
        yield return StartCoroutine(ApplyLuckEffect(this));

        GameManager.currentWheel = true;
        y = false;
    }

    private IEnumerator RunEnemyTurn()
    {
        while (EnemyWheel != null &&
               EnemyWheel.x < (EnemyWheel.baseWheelCount + EnemyWheel.wheelCount) * 2)
        {
            EnemyWheel.spin();
            EnemyWheel.x++;
            yield return new WaitForSeconds(0.35f);

            EnemyWheel.spin();
            EnemyWheel.x++;

            float stopTimeout = 0f;
            while (EnemyWheel.currentRot > 0f && stopTimeout < 12f)
            {
                stopTimeout += Time.deltaTime;
                yield return null;
            }

            if (stopTimeout >= 12f)
            {
                Debug.LogWarning("EnemyWheel wurde nach 12 Sekunden automatisch gestoppt.");
                EnemyWheel.currentRot = 0f;
            }

            EnemyWheel.spinni = false;
            EnemyWheel.drag = false;
            EnemyWheel.execute();

            if (EnemyWheel.RemainingWheels <= 0) break;
            yield return new WaitForSeconds(0.15f);
        }
    }

    private IEnumerator ResolveRoundAfterPlayer()
    {
        if (roundResolutionRunning || battleFinished) yield break;

        roundResolutionRunning = true;
        GameManager.currentWheel = false;

        // Beide Angriffe werden erst nach dem Spielerzug ausgewertet.
        apply();
        if (EnemyWheel != null) EnemyWheel.apply();

        bool playerDead = life <= 0;
        bool enemyDead = EnemyWheel != null && EnemyWheel.life <= 0;

        reset();
        if (EnemyWheel != null) EnemyWheel.reset();
        x = 0;
        if (EnemyWheel != null) EnemyWheel.x = 0;

        if (playerDead)
        {
            battleFinished = true;
            GameManager.currentPhase = 2;

            PlayerWheel player = this as PlayerWheel;
            if (player != null) player.OnDeath();

            roundResolutionRunning = false;
            yield break;
        }

        if (enemyDead)
        {
            if (GameManager.stage >= 30)
            {
                battleFinished = true;
                GameManager.currentPhase = 2;

                PlayerWheel player = this as PlayerWheel;
                if (player != null) player.OnWin();

                roundResolutionRunning = false;
                yield break;
            }

            int defeatedStage = GameManager.stage;
            HealAfterVictory(defeatedStage);

            GameManager.stage = Mathf.Clamp(GameManager.stage + 1, 1, 30);
            EnemyWheel.LoadEnemy(GameManager.stage);
            EnemyWheel.EnemyWheel = this;

            GameManager.currentPhase = 1;
            GameManager.currentWheel = false;

            if (Shopppp != null)
            {
                Shopppp.SetActive(true);
                ShopManager shop = Shopppp.GetComponent<ShopManager>();
                if (shop != null) shop.lastPhase = 0;
            }
            if (IEEE != null) IEEE.SetActive(false);
            if (IE != null) IE.SetActive(false);

            roundResolutionRunning = false;
            yield break;
        }

        // Nächste Kampfrunde: wieder zuerst der Gegner, dann der Spieler.
        yield return StartCoroutine(ApplyLuckEffect(EnemyWheel));
        yield return StartCoroutine(RunEnemyTurn());
        yield return StartCoroutine(ApplyLuckEffect(this));

        GameManager.currentWheel = true;
        roundResolutionRunning = false;
    }

    private void HealAfterVictory(int defeatedStage)
    {
        if (defeatedStage % 5 == 0)
        {
            life = maxLife;
        }
        else
        {
            Heal(Mathf.Max(8, Mathf.CeilToInt(maxLife * 0.15f)));
        }
    }

    private IEnumerator ApplyLuckEffect(Wheel targetWheel)
    {
        if (targetWheel == null) yield break;

        targetWheel.luck = Mathf.Clamp(targetWheel.luck, 0, 100);
        if (UnityEngine.Random.Range(0, 100) >= targetWheel.luck) yield break;

        string luckResult;
        switch (UnityEngine.Random.Range(0, 10))
        {
            case 0:
                targetWheel.damage *= 2;
                luckResult = "2x " + GameManager.Get("damage");
                break;
            case 1:
                targetWheel.damage += 5;
                luckResult = "+5 " + GameManager.Get("damage");
                break;
            case 2:
                targetWheel.armor *= 2;
                luckResult = "2x " + GameManager.Get("armor");
                break;
            case 3:
                targetWheel.armor += 5;
                luckResult = "+5 " + GameManager.Get("armor");
                break;
            case 4:
                targetWheel.target += 1;
                luckResult = "+1 " + GameManager.Get("target");
                break;
            case 5:
                targetWheel.poisen = Mathf.Max(0, targetWheel.poisen - 5);
                luckResult = "-5 " + GameManager.Get("poison");
                break;
            case 6:
                targetWheel.Heal(5);
                luckResult = "+5 " + GameManager.Get("life");
                break;
            case 7:
                targetWheel.weak = Mathf.Max(0, targetWheel.weak - 3);
                luckResult = "-3 " + GameManager.Get("weak");
                break;
            case 8:
                targetWheel.AddBonusWheels(1);
                luckResult = "+1 " + GameManager.Get("wheel");
                break;
            default:
                targetWheel.armor += 10;
                luckResult = "+10 " + GameManager.Get("armor");
                break;
        }

        if (SpecialLuckText == null || lucki == null) yield break;

        SpecialLuckText.gameObject.SetActive(true);
        SpecialLuckText.text = luckResult;
        lucki.SetBool("doit", true);
        yield return new WaitForSeconds(0.1f);
        lucki.SetBool("doit", false);

        LuckText luckTextComponent = lucki.GetComponent<LuckText>();
        if (luckTextComponent != null)
        {
            float animationTimeout = 0f;
            while (luckTextComponent.doit && animationTimeout < 3f)
            {
                animationTimeout += Time.deltaTime;
                yield return null;
            }
        }

        SpecialLuckText.gameObject.SetActive(false);
    }

    private void reset()
    {
        damage = 0;
        armor = 0;
        poisen = Mathf.Max(0, poisen - vacine);
        target = 0;
        wheelCount = 0;
        secondaryEffectDepth = 0;
        type = EffektType.UTILITY;
    }

    public void doPlayer()
    {
        if (!wheel || !GameManager.currentWheel || !h ||
            GameManager.currentPhase != 0 || y ||
            roundResolutionRunning || battleFinished)
        {
            return;
        }

        if (x >= (baseWheelCount + wheelCount) * 2) return;

        x++;
        spin();
    }

    public void apply()
    {
        if (EnemyWheel == null) return;

        int outgoingDamage = Mathf.Max(0, TotalDamage * TotalTargets - weak);
        int damageAfterArmor = Mathf.Max(0, outgoingDamage - EnemyWheel.TotalArmor);
        EnemyWheel.life -= damageAfterArmor;

        life -= EffectivePoison;
    }

    public void spin()
    {
        if (currentRot <= 0f)
        {
            currentRot = UnityEngine.Random.Range(rotRange.x, rotRange.y);
            drag = false;
        }
        else
        {
            h = false;
            drag = true;
            spinni = true;
        }
    }

    public void execute()
    {
        h = true;

        int currentColor = getCurrentColor();
        if (currentColor < 0 || currentColor >= Effekts.Length) return;

        WheelEffekt effect = Effekts[currentColor];
        if (effect == null) return;

        effect.DoEffekt(this);
        type = effect.type;
    }

    public int getCurrentColor()
    {
        int index = ((int)(transform.eulerAngles.z / 45f) + startOffset) % 8;
        return (index + 8) % 8;
    }

    public int getCurses()
    {
        int amount = 0;
        for (int i = 0; i < Effekts.Length; i++)
        {
            if (Effekts[i] != null && Effekts[i].IsCurse) amount++;
        }
        return amount;
    }

    public void AddBonusWheels(int amount)
    {
        if (amount <= 0) return;
        wheelCount = Mathf.Min(maxBonusWheelCount, wheelCount + amount);
    }

    public void AddLuck(int amount)
    {
        luck = Mathf.Clamp(luck + amount, 0, 100);
    }

    public void Heal(int amount)
    {
        if (amount <= 0) return;
        life = Mathf.Min(maxLife, life + amount);
    }

    public void ChangeWheelSpeed(float amount)
    {
        float rangeWidth = Mathf.Max(0.25f, rotRange.y - rotRange.x);
        float maximumMinimum = maximumWheelSpeed - rangeWidth;
        float newMinimum = Mathf.Clamp(rotRange.x + amount, minimumWheelSpeed, maximumMinimum);
        rotRange = new Vector2(newMinimum, newMinimum + rangeWidth);
    }

    public void EndCurrentTurn()
    {
        x = (baseWheelCount + wheelCount) * 2;
    }

    public bool TryTriggerSecondaryEffect(int index)
    {
        if (secondaryEffectDepth > 0) return false;
        if (index < 0 || index >= Effekts.Length) return false;

        WheelEffekt effect = Effekts[index];
        if (effect == null || !effect.CanBeTriggeredAsSecondary) return false;

        secondaryEffectDepth++;
        effect.DoEffekt(this);
        secondaryEffectDepth--;
        return true;
    }

    public void LoadEnemy(int stage)
    {
        stage = Mathf.Clamp(stage, 1, 30);

        damage = 0;
        armor = 0;
        target = 0;
        wheelCount = 0;
        x = 0;
        weak = 0;
        poisen = 0;
        type = EffektType.UTILITY;
        currentRot = 0f;
        drag = false;
        spinni = false;
        h = true;
        rotRange = new Vector2(7f, 8f);

        switch (stage)
        {
            case 1:  ConfigureEnemy(42, 1, 0, 1, 1, 0, 0, EnemyLoadout.Recruit); break;
            case 2:  ConfigureEnemy(48, 1, 1, 1, 1, 2, 0, EnemyLoadout.Guard); break;
            case 3:  ConfigureEnemy(52, 2, 0, 1, 1, 0, 0, EnemyLoadout.PoisonHunter); break;
            case 4:  ConfigureEnemy(60, 2, 1, 1, 1, 4, 0, EnemyLoadout.Berserker); break;
            case 5:  ConfigureEnemy(85, 3, 3, 1, 1, 5, 1, EnemyLoadout.Guard); break;
            case 6:  ConfigureEnemy(70, 2, 1, 1, 1, 4, 1, EnemyLoadout.Berserker); break;
            case 7:  ConfigureEnemy(76, 3, 2, 1, 1, 2, 1, EnemyLoadout.Guard); break;
            case 8:  ConfigureEnemy(82, 2, 2, 1, 1, 6, 1, EnemyLoadout.WheelRunner); break;
            case 9:  ConfigureEnemy(94, 3, 3, 1, 1, 8, 1, EnemyLoadout.Control); break;
            case 10: ConfigureEnemy(130, 4, 4, 1, 2, 10, 2, EnemyLoadout.Gambler); break;
            case 11: ConfigureEnemy(100, 4, 2, 1, 1, 5, 2, EnemyLoadout.PoisonHunter); break;
            case 12: ConfigureEnemy(108, 4, 3, 1, 1, 8, 2, EnemyLoadout.Control); break;
            case 13: ConfigureEnemy(116, 5, 2, 1, 1, 6, 2, EnemyLoadout.Berserker); break;
            case 14: ConfigureEnemy(130, 5, 4, 1, 1, 10, 2, EnemyLoadout.Plague); break;
            case 15: ConfigureEnemy(178, 6, 5, 1, 2, 12, 3, EnemyLoadout.Plague); break;
            case 16: ConfigureEnemy(142, 5, 3, 1, 1, 12, 3, EnemyLoadout.Gambler); break;
            case 17: ConfigureEnemy(152, 6, 3, 1, 1, 10, 3, EnemyLoadout.Berserker); break;
            case 18: ConfigureEnemy(165, 5, 4, 1, 2, 14, 3, EnemyLoadout.WheelRunner); break;
            case 19: ConfigureEnemy(182, 6, 5, 1, 2, 16, 3, EnemyLoadout.Control); break;
            case 20: ConfigureEnemy(240, 7, 6, 1, 2, 18, 4, EnemyLoadout.WheelRunner); break;
            case 21:
                ConfigureEnemy(195, 7, 4, 1, 1, 15, 4, EnemyLoadout.Cursed);
                poisen = 2;
                break;
            case 22: ConfigureEnemy(210, 7, 5, 1, 2, 18, 4, EnemyLoadout.Control); break;
            case 23: ConfigureEnemy(225, 8, 4, 1, 2, 16, 4, EnemyLoadout.Plague); break;
            case 24:
                ConfigureEnemy(245, 8, 6, 1, 2, 20, 4, EnemyLoadout.Cursed);
                poisen = 2;
                weak = 1;
                break;
            case 25:
                ConfigureEnemy(320, 8, 7, 2, 1, 22, 5, EnemyLoadout.Cursed);
                poisen = 4;
                weak = 2;
                break;
            case 26: ConfigureEnemy(265, 9, 5, 1, 2, 20, 5, EnemyLoadout.Berserker); break;
            case 27: ConfigureEnemy(285, 9, 6, 1, 2, 22, 5, EnemyLoadout.Plague); break;
            case 28:
                ConfigureEnemy(310, 10, 6, 1, 2, 24, 5, EnemyLoadout.CursedClockwork);
                poisen = 2;
                break;
            case 29:
                ConfigureEnemy(340, 10, 8, 1, 2, 26, 5, EnemyLoadout.Cursed);
                poisen = 2;
                weak = 1;
                break;
            case 30:
                ConfigureEnemy(460, 9, 9, 2, 2, 30, 6, EnemyLoadout.FinalBoss);
                poisen = 5;
                weak = 2;
                break;
        }
    }

    private enum EnemyLoadout
    {
        Recruit,
        Guard,
        PoisonHunter,
        Berserker,
        WheelRunner,
        Control,
        Gambler,
        Plague,
        Cursed,
        CursedClockwork,
        FinalBoss
    }

    private void ConfigureEnemy(
        int enemyLife,
        int enemyBaseDamage,
        int enemyBaseArmor,
        int enemyBaseTargets,
        int enemyBaseWheels,
        int enemyLuck,
        int enemyVaccine,
        EnemyLoadout loadout)
    {
        maxLife = enemyLife;
        life = enemyLife;
        baseDamage = enemyBaseDamage;
        baseArmor = enemyBaseArmor;
        baseTarget = enemyBaseTargets;
        baseWheelCount = enemyBaseWheels;
        luck = Mathf.Clamp(enemyLuck, 0, 100);
        vacine = Mathf.Max(0, enemyVaccine);

        LoadEnemyEffects(loadout);
    }

    private void LoadEnemyEffects(EnemyLoadout loadout)
    {
        switch (loadout)
        {
            case EnemyLoadout.Recruit:
                SetEnemyEffects(new DamageEffekt(2), new DamageEffekt(2), new DamageEffekt(2), new DamageEffekt(2), new DamageEffekt(2), new DamageEffekt(2), new DamageEffekt(4), new IronSkin());
                break;
            case EnemyLoadout.Guard:
                SetEnemyEffects(new DamageEffekt(2), new DamageEffekt(2), new DamageEffekt(2), new IronSkin(), new IronSkin(), new RustyShield(), new SpikePlating(), new TacticalStop());
                break;
            case EnemyLoadout.PoisonHunter:
                SetEnemyEffects(new DamageEffekt(2), new DamageEffekt(2), new DamageEffekt(4), new DebilitatingPoison(), new DebilitatingPoison(), new ToxicShield(), new Attrition(), new LeechSwarm());
                break;
            case EnemyLoadout.Berserker:
                SetEnemyEffects(new DamageEffekt(2), new DamageEffekt(2), new DamageEffekt(4), new Overload(), new DoubleStrike(), new ArmorBreak(), new Haste(), new VengeanceStrike());
                break;
            case EnemyLoadout.WheelRunner:
                SetEnemyEffects(new DamageEffekt(2), new DamageEffekt(2), new ExtraSpin(), new HeavyFlywheel(), new Recoil(), new Momentum(), new Haste(), new IronSkin());
                break;
            case EnemyLoadout.Control:
                SetEnemyEffects(new DamageEffekt(2), new DamageEffekt(2), new ArmorBreak(), new Attrition(), new PrecisionStrike(), new WeaknessCascade(), new TacticalStop(), new EnergyShield());
                break;
            case EnemyLoadout.Gambler:
                SetEnemyEffects(new DamageEffekt(2), new DamageEffekt(2), new CoinFlip(), new EnergyShield(), new LuckyHit(), new TacticalStop(), new AllOrNothing(), new Jackpot());
                break;
            case EnemyLoadout.Plague:
                SetEnemyEffects(new DamageEffekt(2), new DebilitatingPoison(), new DebilitatingPoison(), new Decomposition(), new LastGasp(), new LeechSwarm(), new ToxicShield(), new Attrition());
                break;
            case EnemyLoadout.Cursed:
                SetEnemyEffects(new CurseGlassFracture(), new CurseRigorMortis(), new CurseParasiticPact(), new SynergyCurseCatalyst(), new SynergyDefiance(), new SynergyScapegoat(), new EnergyShield(), new DamageEffekt(2));
                break;
            case EnemyLoadout.CursedClockwork:
                SetEnemyEffects(new CurseRigorMortis(), new SynergyCurseCatalyst(), new ExtraSpin(), new HeavyFlywheel(), new Recoil(), new Momentum(), new EnergyShield(), new DamageEffekt(2));
                break;
            case EnemyLoadout.FinalBoss:
                SetEnemyEffects(new CurseLeadWeight(), new CurseRigorMortis(), new SynergyCurseCatalyst(), new Overload(), new PrecisionStrike(), new ToxicShield(), new EnergyShield(), new VengeanceStrike());
                break;
        }
    }

    private void SetEnemyEffects(params WheelEffekt[] effects)
    {
        if (effects == null || effects.Length != 8)
        {
            Debug.LogError("Ein Gegner-Rad muss genau acht Effekte besitzen.");
            return;
        }

        for (int i = 0; i < Effekts.Length; i++)
        {
            Effekts[i] = effects[i];
        }
    }
}
