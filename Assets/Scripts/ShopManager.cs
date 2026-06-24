using System.Collections;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public SegmentEntry[] entrys = new SegmentEntry[3];
    private int lastPhase = 0;
    public int dubai = 0;
    public GameObject AskField;
    public TMP_Text AskFieldText;
    public TMP_Text ErrorText;
    public GameObject errorField;
    public Wheel playeri;
    void Update()
    {
        if (GameManager.currentPhase == 1&& lastPhase != 1)
        {
            for (int i = 0; i < entrys.Length; i++)
            {
                entrys[i].gameObject.SetActive(true);
            }
        }else if (GameManager.currentPhase == 0 && lastPhase != 0)
        {
            for (int i = 0; i < entrys.Length; i++)
            {
                entrys[i].gameObject.SetActive(false);
            }
        }
        lastPhase = GameManager.currentPhase;
    }
    public void Buy(SegmentEntry segmentEntry)
    {
        StartCoroutine(BuyItem(segmentEntry));
    }
    public void close(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    public IEnumerator BuyItem(SegmentEntry segmentEntry)
    {
        if (errorField.activeSelf) yield break;
        if (AskField.activeSelf) yield break;
        if (!segmentEntry.effekt.haveCost(playeri))
        {
            errorField.SetActive(true);
            ErrorText.text = segmentEntry.effekt.name;
            yield break;
        }
        AskField.gameObject.SetActive(true);
        AskFieldText.text = segmentEntry.effekt.name;
        yield return new WaitUntil(()=>(dubai==1|| dubai == 2));
        AskField.gameObject.SetActive(false);
        if(dubai == 1)
        {
            playeri.Effekts[segmentEntry.effekt.color] = segmentEntry.effekt;
            segmentEntry.gameObject.SetActive(false);
        }
        else
        {

        }

        dubai = 0;
    }
    public void setDubai(int dubai)
    {
        this.dubai = dubai;
    }
}
