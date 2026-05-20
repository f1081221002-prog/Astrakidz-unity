using System.Collections;
using UnityEngine;

public class RocketIntro : MonoBehaviour
{
    [Header("Posisi Rocket")]
    public Vector2 startPosition =
        new Vector2(3.5f, -565f);

    public Vector2 endPosition =
        new Vector2(3.5f, 0f);

    [Header("Animasi Naik")]
    public float moveDuration = 2f;

    [Header("Floating")]
    public bool enableFloating = true;

    public float floatingAmount = 20f;

    public float floatingSpeed = 2f;

    private RectTransform rectTransform;

    private Vector2 basePosition;

    void Start()
    {
        rectTransform =
            GetComponent<RectTransform>();

        // Posisi awal
        rectTransform.anchoredPosition =
            startPosition;

        StartCoroutine(
            MoveRocket()
        );
    }

    IEnumerator MoveRocket()
    {
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;

            float t =
                elapsed / moveDuration;

            // EaseOut smooth
            float smoothT =
                1f - Mathf.Pow(
                    1f - t,
                    3f
                );

            rectTransform.anchoredPosition =
                Vector2.Lerp(
                    startPosition,
                    endPosition,
                    smoothT
                );

            yield return null;
        }

        // Posisi akhir fix
        rectTransform.anchoredPosition =
            endPosition;

        basePosition =
            endPosition;

        // Floating
        if (enableFloating)
        {
            StartCoroutine(
                FloatingAnimation()
            );
        }

        // Cari semua BounceFadeIn
        BounceFadeIn[] allBounceObjects =
            FindObjectsByType<BounceFadeIn>(
                FindObjectsSortMode.None
            );

        // Jalankan semua
        foreach (
            BounceFadeIn bounce
            in allBounceObjects
        )
        {
            if (bounce != null)
            {
                bounce.Play();
            }
        }
    }

    IEnumerator FloatingAnimation()
    {
        while (true)
        {
            float yOffset =
                Mathf.Sin(
                    Time.time *
                    floatingSpeed
                ) * floatingAmount;

            rectTransform.anchoredPosition =
                new Vector2(
                    basePosition.x,
                    basePosition.y + yOffset
                );

            yield return null;
        }
    }
}