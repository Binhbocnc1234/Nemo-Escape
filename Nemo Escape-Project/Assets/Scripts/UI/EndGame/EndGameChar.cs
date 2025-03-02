using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndGameChar : MonoBehaviour
{
    public float startY = -50f; // Initial position ('b')
    public float endY = 0f; // Target position ('a')
    public float duration = 1f; // Lerp time
    public Image charImage; // Assign in Inspector
    private RectTransform rectTransform;

    void OnEnable()
    {
        GetComponent<HarmonicOscillation>().enabled = true;

        rectTransform = GetComponent<RectTransform>();

        if (charImage == null)
            charImage = GetComponent<Image>();

        StartCoroutine(LerpEffect());
    }

    private IEnumerator LerpEffect()
    {
        float elapsedTime = 0f;
        Vector2 startPos = new Vector2(rectTransform.anchoredPosition.x, startY);
        Vector2 targetPos = new Vector2(startPos.x, endY);

        Color startColor = charImage.color;
        startColor.a = 0f;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        // Set starting values
        rectTransform.anchoredPosition = startPos;
        charImage.color = startColor;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);
            charImage.color = Color.Lerp(startColor, targetColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 🔹 **Fix: Ensure the final position and color are set**
        // rectTransform.anchoredPosition = targetPos;
        // charImage.color = targetColor;
    }
}
