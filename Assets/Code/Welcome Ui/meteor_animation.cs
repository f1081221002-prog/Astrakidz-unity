using System.Collections;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [Header("Posisi")]
    public Vector2 startPosition;
    public Vector2 endPosition;

    [Header("Pengaturan")]
    public float moveDuration = 4f;

    [Header("Respawn Delay")]
    public float minDelay = 1f;
    public float maxDelay = 5f;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        rectTransform.anchoredPosition = startPosition;

        StartCoroutine(MeteorLoop());
    }

    IEnumerator MeteorLoop()
    {
        while (true)
        {
            // Delay random sebelum muncul
            float randomDelay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomDelay);

            // Reset posisi
            rectTransform.anchoredPosition = startPosition;

            // Show
            if (canvasGroup != null)
                canvasGroup.alpha = 1;

            // Gerakan meteor
            float elapsed = 0f;

            while (elapsed < moveDuration)
            {
                elapsed += Time.deltaTime;

                float t = elapsed / moveDuration;

                rectTransform.anchoredPosition =
                    Vector2.Lerp(startPosition, endPosition, t);

                yield return null;
            }

            // Pastikan sampai tujuan
            rectTransform.anchoredPosition = endPosition;

            // Hide meteor
            if (canvasGroup != null)
                canvasGroup.alpha = 0;
        }
    }
}