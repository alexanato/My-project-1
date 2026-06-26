using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpriteFlip : MonoBehaviour
{
    public Sprite toChange;
    private static float flipInterval = 0.5f;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();

            StartCoroutine(FlipSpriteRoutine());
    }

    private IEnumerator FlipSpriteRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(flipInterval);

            Sprite currentSprite = image.sprite;
            image.sprite = toChange;
            toChange = currentSprite;
        }
    }
}