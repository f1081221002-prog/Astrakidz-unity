using System.Collections;
using UnityEngine;

public class AutoMoveRotate : MonoBehaviour
{
    [Header("Posisi Awal")]
    public Vector3 startPosition = new Vector3(-100f, 560f, 0f);

    [Header("Posisi Tujuan")]
    public Vector3 targetPosition = new Vector3(1737.3f, 560f, 0f);

    [Header("Rotasi")]
    public float targetRotation = 1080f;

    [Header("Durasi")]
    public float duration = 40f;

    private bool animating = false;

    void Update()
    {
        // Otomatis jalan kalau object aktif dan belum animasi
        if (gameObject.activeInHierarchy && !animating)
        {
            StartCoroutine(MoveObject());
        }
    }

    IEnumerator MoveObject()
    {
        if (animating)
            yield break;

        animating = true;

        // Reset posisi awal
        transform.localPosition = startPosition;
        transform.localRotation = Quaternion.Euler(0, 0, 0);

        float time = 0f;

        Vector3 initialPos = startPosition;
        Quaternion initialRot = Quaternion.Euler(0, 0, 0);
        Quaternion finalRot = Quaternion.Euler(0, 0, targetRotation);

        while (time < duration)
        {
            float t = time / duration;

            // Gerak posisi
            transform.localPosition = Vector3.Lerp(initialPos, targetPosition, t);

            // Rotasi
            transform.localRotation = Quaternion.Lerp(initialRot, finalRot, t);

            time += Time.deltaTime;
            yield return null;
        }

        // Pastikan tepat di akhir
        transform.localPosition = targetPosition;
        transform.localRotation = finalRot;

        // Reset seperti AS3
        transform.localPosition = startPosition;
        transform.localRotation = Quaternion.Euler(0, 0, 0);

        animating = false;
    }

    void OnDisable()
    {
        StopAllCoroutines();
        animating = false;
    }
}