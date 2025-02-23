using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTrigger : MonoBehaviour
{
    public Text text; // Assign the Text component in the Inspector
    public float scaleMultiplier = 1.2f; // How much the text scales up
    public float duration = 0.5f; // Time to complete the effect

    private Vector3 originalScale;
    private Color originalColor;

    void Start()
    {
        if (text == null)
            text = GetComponent<Text>();

        originalScale = text.transform.localScale;
        originalColor = text.color;
    }

    public void Trigger()
    {
        StopAllCoroutines(); // Prevent overlapping effects
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        float elapsedTime = 0f;
        text.color = Color.yellow; // Change color to yellow
        Vector3 targetScale = originalScale * scaleMultiplier;

        // Scale Up
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            text.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Hold at max scale briefly
        text.transform.localScale = targetScale;
        yield return new WaitForSeconds(0.1f);

        elapsedTime = 0f;
        
        // Scale Down
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            text.transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Restore original state
        text.transform.localScale = originalScale;
        text.color = originalColor;
    }
}
