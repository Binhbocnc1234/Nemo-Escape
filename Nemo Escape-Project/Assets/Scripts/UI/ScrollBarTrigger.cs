using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollBarTrigger : MonoBehaviour
{
    public Scrollbar scrollbar; // Assign in Inspector
    public Image handleImage; // Assign the handle Image in Inspector
    public float targetSize = 0.2f; // Desired size of the handle
    public float lerpSpeed = 5f; // Speed of size transition
    public Color targetColor = Color.yellow; // Color when changing size

    private float originalSize;
    private Color originalColor;

    void Start()
    {
        if (scrollbar == null)
            scrollbar = GetComponent<Scrollbar>();

        if (handleImage == null)
            handleImage = scrollbar.handleRect.GetComponent<Image>();

        originalSize = scrollbar.size;
        originalColor = handleImage.color;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<ScrollBarTrigger>().ChangeSize(Random.Range(0, 1));
        }
    }

    public void ChangeSize(float newSize)
    {
        if (Mathf.Clamp01(newSize) == targetSize){
            return;
        }
        targetSize = Mathf.Clamp01(newSize); // Ensure it's between 0 and 1
        StopAllCoroutines();
        StartCoroutine(LerpSize());
    }

    private IEnumerator LerpSize()
    {
        float startSize = scrollbar.size;
        float elapsedTime = 0f;
        handleImage.color = targetColor; // Change color to targetColor

        while (elapsedTime < 1f)
        {
            scrollbar.size = Mathf.Lerp(startSize, targetSize, elapsedTime);
            elapsedTime += Time.deltaTime * lerpSpeed;
            yield return null;
        }

        scrollbar.size = targetSize;
        handleImage.color = originalColor; // Restore original color
    }
}
