using System.Collections;
using UnityEngine;

public class AutoButtonPulse : MonoBehaviour
{
    [Header("Ukuran Zoom")]
    public float maxScale = 1.1f;
    public float minScale = 0.9f;

    [Header("Kecepatan")]
    public float duration = 1f;

    [Header("Tunggu BounceFadeIn Selesai")]
    public bool waitBounceFadeIn = true;

    private bool zoomIn = true;

    private Vector3 originalScale;

    private BounceFadeIn bounceFadeIn;

    IEnumerator Start()
    {
        originalScale =
            transform.localScale;

        // Cari component BounceFadeIn
        bounceFadeIn =
            GetComponent<BounceFadeIn>();

        // Tunggu BounceFadeIn selesai
        if (waitBounceFadeIn &&
            bounceFadeIn != null)
        {
            yield return new WaitForSeconds(
                bounceFadeIn.duration
            );
        }

        // Mulai pulse
        StartCoroutine(
            AnimateZoom()
        );
    }

    IEnumerator AnimateZoom()
    {
        while (true)
        {
            float target =
                zoomIn ? maxScale : minScale;

            Vector3 startScale =
                transform.localScale;

            Vector3 endScale =
                originalScale * target;

            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;

                float t =
                    elapsed / duration;

                t = Mathf.SmoothStep(0f, 1f, t);

                transform.localScale =
                    Vector3.Lerp(
                        startScale,
                        endScale,
                        t
                    );

                yield return null;
            }

            transform.localScale =
                endScale;

            zoomIn = !zoomIn;
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}