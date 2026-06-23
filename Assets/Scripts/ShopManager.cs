using System.Collections;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public SegmentEntry[] entrys = new SegmentEntry[3];
    private int lastPhase = 0;
    public int dubai = 0;
    public GameObject AskField;
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
    public IEnumerator BuyItem(SegmentEntry segmentEntry)
    {
        AskField.gameObject.SetActive(true);
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
