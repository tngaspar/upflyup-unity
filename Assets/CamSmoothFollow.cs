using UnityEngine;

public class CamSmoothFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public int camLowerY = 19;
    public float[] xInterval = new float[2];
  
    private float screenWidth;
    private void Start()
    {
        Debug.Log("Screen width :" + Screen.width);
        
        Vector3 p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 p2 = Camera.main.ScreenToWorldPoint(Vector3.right);
        float pixelPerUnit = 1/Vector3.Distance(p1, p2);
        Debug.Log("PixelsperUnit :" + pixelPerUnit);
        screenWidth = (Screen.width / 2) / pixelPerUnit;

    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = transform.position = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;
        if (transform.position.y < camLowerY)
        {
            transform.position = new Vector3(transform.position.x, camLowerY, transform.position.z);
        }
        
        if (transform.position.x < xInterval[0] + screenWidth)
        {
            transform.position = new Vector3(xInterval[0] + screenWidth, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xInterval[1] - screenWidth)
        {
            transform.position = new Vector3(xInterval[1] - screenWidth, transform.position.y, transform.position.z);
        }
    }




}

