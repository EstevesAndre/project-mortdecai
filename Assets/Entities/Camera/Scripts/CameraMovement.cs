using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public Transform target;
    public Vector3 CameraRelativePoint = new Vector3(0, 5, -12);
    public float smoothTime = 0.1F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(CameraRelativePoint);
        Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y - CameraRelativePoint.y, target.transform.position.z - CameraRelativePoint.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}