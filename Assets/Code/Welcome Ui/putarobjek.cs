using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [Header("Rotasi")]
    public float rotationSpeed = 180f;

    [Header("Arah Rotasi")]
    public bool clockwise = true;

    void Update()
    {
        float direction = clockwise ? -1f : 1f;

        transform.Rotate(
            0,
            0,
            rotationSpeed * direction * Time.deltaTime
        );
    }
}