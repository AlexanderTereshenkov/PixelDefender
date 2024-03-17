using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float smoothTime;

    public Transform Target { get; set; }

    private Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 velocity;

    void Update()
    {
        Vector3 targetTransform = Target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetTransform, ref velocity, smoothTime);
    }
}
