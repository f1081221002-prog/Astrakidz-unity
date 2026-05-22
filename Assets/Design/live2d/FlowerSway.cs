using UnityEngine;

public class FlowerSway : MonoBehaviour
{
    [Header("Bone")]
    public Transform bone1;
    public Transform bone2;

    [Header("Gerakan")]
    public float speed = 1.2f;

    [Header("Kekuatan")]
    public float bone1Angle = 2f;
    public float bone2Angle = 5f;

    private Quaternion bone1StartRot;
    private Quaternion bone2StartRot;

    void Start()
    {
        bone1StartRot = bone1.localRotation;
        bone2StartRot = bone2.localRotation;
    }

    void Update()
    {
        // Bone bawah
        float rot1 =
            Mathf.Sin(Time.time * speed)
            * bone1Angle;

        // Bone atas
        float rot2 =
            Mathf.Sin(Time.time * speed + 0.4f)
            * bone2Angle;

        bone1.localRotation =
            bone1StartRot *
            Quaternion.Euler(0, 0, rot1);

        bone2.localRotation =
            bone2StartRot *
            Quaternion.Euler(0, 0, rot2);
    }
}