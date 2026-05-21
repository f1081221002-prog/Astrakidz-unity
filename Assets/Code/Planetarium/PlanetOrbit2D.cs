using UnityEngine;

public class PlanetOrbit2D : MonoBehaviour
{
    [Header("Pusat Orbit")]
    public Transform sun;

    [Header("Radius Orbit")]
    public float radiusX = 200f;
    public float radiusY = 100f;

    [Header("Kecepatan")]
    public float orbitSpeed = 10f;

    [Header("Sudut Awal")]
    public float startAngle = 0f;

    private float angle;

    void Start()
    {
        angle = startAngle;
    }

    void Update()
    {
        angle += orbitSpeed * Time.deltaTime;

        float rad = angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(rad) * radiusX;
        float y = Mathf.Sin(rad) * radiusY;

        transform.localPosition =
            sun.localPosition + new Vector3(x, y, 0);
    }
}