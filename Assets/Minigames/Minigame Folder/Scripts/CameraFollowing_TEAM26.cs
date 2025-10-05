using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollowing_TEAM26 : MonoBehaviour
{
    public Transform target;
    public Tilemap map;
    public float smoothSpeed = 0.125f;

    private Vector3 minBounds;
    private Vector3 maxBounds;
    private float camHalfHeight;
    private float camHalfWidth;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;

        if (map != null)
        {
            minBounds = map.localBounds.min;
            maxBounds = map.localBounds.max;
        }
    }

    void LateUpdate()
    {
        if (target == null || map == null)
            return;

        float clampedX = Mathf.Clamp(target.position.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(target.position.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        Vector3 targetPos = new Vector3(clampedX, clampedY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
    }
}
