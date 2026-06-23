using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SegmentEntry : MonoBehaviour
{
    public ShopManager shopManager;
    public WheelEffekt effekt;
    public TMP_Text Desc;
    public TMP_Text cost;
    public Image bg;
    private void Start()
    {
        effekt = new DamageEffekt(4);
    }
    private void Update()
    {
        Desc.text = effekt.Description;
        bg.color = GameManager.WheelColor[effekt.color];
        cost.text = effekt.Cost;
    }
    public void Buy()
    {
        shopManager.Buy(this);
    }
}
