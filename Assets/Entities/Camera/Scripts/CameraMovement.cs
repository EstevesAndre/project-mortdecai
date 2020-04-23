using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public Transform target;
    public float smoothTime = 0.1F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 1, -10));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}