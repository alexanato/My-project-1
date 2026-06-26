using System.Collections;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public SegmentEntry[] entrys = new SegmentEntry[3];
    public int lastPhase = 0;
    public int dubai = 0;
    public GameObject AskField;
    public TMP_Text AskFieldText;
    public TMP_Text ErrorText;
    public GameObject errorField;
    public Wheel playeri;
    public EffectManager effectManager;

    private void Start()
    {
        if (playeri == null)
        {
            playeri = GameManager.PlayerWheel;
            if (playeri == null)
            {
                playeri = UnityEngine.Object.FindFirstObjectByType<PlayerWheel>();
            }
        }

        if (effectManager == null)
        {
            effectManager = UnityEngine.Object.FindFirstObjectByType<EffectManager>();
        }
    }

    private void Update()
    {
        if (GameManager.currentPhase == 1 && lastPhase != 1)
        {
            GenerateOffers();
        }
        else if (GameManager.currentPhase != 1 && lastPhase == 1)
        {
            HideOffers();
        }

        lastPhase = GameManager.currentPhase;
    }

    private void GenerateOffers()
    {
        if (entrys == null)
        {
            return;
        }

        for (int i = 0; i < entrys.Length; i++)
        {
            SegmentEntry entry = entrys[i];
            if (entry == null)
            {
                continue;
            }

            entry.effekt = CreateOffer();
            entry.gameObject.SetActive(entry.effekt != null);
        }

        if (!HasBuyableOffer() && entrys.Length > 0 && entrys[0] != null)
        {
            for (int attempt = 0; attempt < 100; attempt++)
            {
                WheelEffekt candidate = CreateOffer();
                if (!CanBuy(candidate))
                {
                    continue;
                }

                entrys[0].effekt = candidate;
                entrys[0].gameObject.SetActive(true);
                break;
            }
        }
    }

    private void HideOffers()
    {
        if (entrys == null)
        {
            return;
        }

        for (int i = 0; i < entrys.Length; i++)
        {
            if (entrys[i] != null)
            {
                entrys[i].gameObject.SetActive(false);
            }
        }
    }

    private WheelEffekt CreateOffer()
    {
        if (effectManager == null)
        {
            return null;
        }

        WheelEffekt effect = effectManager.CreateRandomEffect();
        if (effect != null)
        {
            effect.color = Random.Range(0, 8);
        }

        return effect;
    }

    private bool HasBuyableOffer()
    {
        if (entrys == null)
        {
            return false;
        }

        for (int i = 0; i < entrys.Length; i++)
        {
            if (entrys[i] != null && CanBuy(entrys[i].effekt))
            {
                return true;
            }
        }

        return false;
    }

    private bool CanBuy(WheelEffekt effect)
    {
        if (effect == null || playeri == null || playeri.Effekts == null)
        {
            return false;
        }

        int color = Mathf.Clamp(effect.color, 0, playeri.Effekts.Length - 1);
        WheelEffekt currentEffect = playeri.Effekts[color];

        return effect.haveCost(playeri) &&
               (currentEffect == null || !currentEffect.IsCurse);
    }

    public void Buy(SegmentEntry segmentEntry)
    {
        if (segmentEntry != null)
        {
            StartCoroutine(BuyItem(segmentEntry));
        }
    }

    public void close(GameObject gameObject)
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }

    public IEnumerator BuyItem(SegmentEntry segmentEntry)
    {
        if (GameManager.currentPhase != 1)
        {
            yield break;
        }

        if (errorField != null && errorField.activeSelf)
        {
            yield break;
        }

        if (AskField != null && AskField.activeSelf)
        {
            yield break;
        }

        if (segmentEntry == null || segmentEntry.effekt == null || playeri == null)
        {
            yield break;
        }

        int color = Mathf.Clamp(segmentEntry.effekt.color, 0, playeri.Effekts.Length - 1);
        WheelEffekt currentEffect = playeri.Effekts[color];

        if (currentEffect != null && currentEffect.IsCurse)
        {
            ShowError("this segment is cursed ");
            yield break;
        }

        if (!segmentEntry.effekt.haveCost(playeri))
        {
            ShowError("too expensive " + segmentEntry.effekt.Cost);
            yield break;
        }

        dubai = 0;
        if (AskField != null)
        {
            AskField.SetActive(true);
        }

        if (AskFieldText != null)
        {
            AskFieldText.text = segmentEntry.effekt.name;
        }

        yield return new WaitUntil(() => dubai == 1 || dubai == 2 || GameManager.currentPhase != 1);

        if (AskField != null)
        {
            AskField.SetActive(false);
        }

        if (dubai == 1 && GameManager.currentPhase == 1)
        {
            segmentEntry.effekt.doCost(playeri);
            segmentEntry.effekt.color = color;
            playeri.Effekts[color] = segmentEntry.effekt;
            segmentEntry.gameObject.SetActive(false);
        }

        dubai = 0;
    }

    private void ShowError(string message)
    {
        if (errorField != null)
        {
            errorField.SetActive(true);
        }

        if (ErrorText != null)
        {
            ErrorText.text = message;
        }
    }

    public void setDubai(int dubai)
    {
        this.dubai = dubai;
    }
}
