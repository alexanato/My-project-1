using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SegmentEntry : MonoBehaviour
{
    public ShopManager shopManager;
    public WheelEffekt effekt;
    public TMP_Text Desc;
    public TMP_Text cost;
    public TMP_Text name;
    public Image bg;

    private void Start()
    {
        if (effekt == null)
        {
            effekt = new DamageEffekt(4);
        }
    }

    private void Update()
    {
        if (effekt == null) return;

        if (Desc != null) Desc.text = effekt.Description;
        if (bg != null) bg.color = GameManager.WheelColor[Mathf.Clamp(effekt.color, 0, 7)];
        if (cost != null) cost.text = effekt.Cost;
        if (name != null) name.text = effekt.name;
    }

    public void Buy()
    {
        if (shopManager != null)
        {
            shopManager.Buy(this);
        }
    }
}
