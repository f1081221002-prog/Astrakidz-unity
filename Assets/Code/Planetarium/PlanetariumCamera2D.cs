using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetariumCamera2D : MonoBehaviour
{
    [Header("Zoom")]
    public float zoomSpeed = 0.1f;
    public float minScale = 0.5f;
    public float maxScale = 2f;

    [Header("Drag")]
    public float dragSpeed = 1f;

    private Vector3 lastMousePosition;

    void Update()
    {
        HandleZoom();
        HandleDrag();
    }

    void HandleZoom()
    {
        float scroll = Input.mouseScrollDelta.y;

        if (scroll != 0)
        {
            Vector3 scale = transform.localScale;

            scale += Vector3.one * scroll * zoomSpeed;

            scale.x = Mathf.Clamp(scale.x, minScale, maxScale);
            scale.y = Mathf.Clamp(scale.y, minScale, maxScale);

            transform.localScale = scale;
        }
    }

    void HandleDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta =
                Input.mousePosition - lastMousePosition;

            transform.localPosition += delta * dragSpeed;

            lastMousePosition = Input.mousePosition;
        }
    }
}