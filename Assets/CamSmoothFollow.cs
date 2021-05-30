using UnityEngine;

public class CamSmoothFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public int camLowerY = 19;
    public int[] xInterval = new int[2];

    private void LateUpdate()
    {
        Vector3 desiredPosition = transform.position = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;
        if (transform.position.y < camLowerY)
        {
            transform.position = new Vector3(transform.position.x, camLowerY, transform.position.z);
        }
        
        if (transform.position.x < xInterval[0])
        {
            transform.position = new Vector3(xInterval[0], transform.position.y, transform.position.z);
        }

        if (transform.position.x > xInterval[1])
        {
            transform.position = new Vector3(xInterval[1], transform.position.y, transform.position.z);
        }
    }
}
