using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;

    private Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 velocity;

    void Update()
    {
        Vector3 targetTransform = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetTransform, ref velocity, smoothTime);
    }
}
