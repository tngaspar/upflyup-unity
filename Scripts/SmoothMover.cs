using UnityEngine;

public class SmoothMover : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private float loopDuration = 1f;
    [SerializeField] private float deltaMultiplier = 1f;
    private void Start()
    {
        transform.position = start.position;
        InvokeRepeating("ObjectReset", loopDuration, loopDuration);
    }

    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, end.position, Time.deltaTime * deltaMultiplier);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(start.position, Vector3.one * 0.1f);
        Gizmos.DrawCube(end.position, Vector3.one * 0.1f);
    }


    private void ObjectReset()
    {
        transform.position = start.position;
    }
}