using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BounceFadeIn : MonoBehaviour
{
    [Header("Bounce")]
    public float bounceDistance = 55f;

    public float duration = 2f;

    private RectTransform rectTransform;
    private Graphic graphic;

    private Vector2 originalPosition;

    void Awake()
    {
        rectTransform =
            GetComponent<RectTransform>();

        graphic =
            GetComponent<Graphic>();

        // Simpan posisi asli
        originalPosition =
            rectTransform.anchoredPosition;

        // Invisible awal
        if (graphic != null)
        {
            Color c =
                graphic.color;

            c.a = 0;

            graphic.color = c;
        }
    }

    public void Play()
    {
        StartCoroutine(
            PlayBounce()
        );
    }

    IEnumerator PlayBounce()
    {
        float elapsed = 0f;

        // Posisi mulai dari bawah
        Vector2 startPos =
            originalPosition -
            new Vector2(0, bounceDistance);

        rectTransform.anchoredPosition =
            startPos;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float t =
                elapsed / duration;

            float bounceT =
                EaseOutBounce(t);

            // Bounce gerak
            rectTransform.anchoredPosition =
                Vector2.Lerp(
                    startPos,
                    originalPosition,
                    bounceT
                );

            // Fade alpha image
            if (graphic != null)
            {
                Color c =
                    graphic.color;

                c.a = bounceT;

                graphic.color = c;
            }

            yield return null;
        }

        rectTransform.anchoredPosition =
            originalPosition;

        // Final alpha fix
        if (graphic != null)
        {
            Color c =
                graphic.color;

            c.a = 1;

            graphic.color = c;
        }
    }

    float EaseOutBounce(float x)
    {
        float n1 = 7.5625f;
        float d1 = 2.75f;

        if (x < 1f / d1)
        {
            return n1 * x * x;
        }
        else if (x < 2f / d1)
        {
            x -= 1.5f / d1;
            return n1 * x * x + 0.75f;
        }
        else if (x < 2.5f / d1)
        {
            x -= 2.25f / d1;
            return n1 * x * x + 0.9375f;
        }
        else
        {
            x -= 2.625f / d1;
            return n1 * x * x + 0.984375f;
        }
    }
}