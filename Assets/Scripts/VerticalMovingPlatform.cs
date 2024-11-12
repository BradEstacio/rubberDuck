using UnityEngine;
public class VerticalMovingPlatform : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;
    private Vector3 startPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 targetPos = startPos + (movingUp ? Vector3.up : Vector3.down) * moveDistance;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            movingUp = !movingUp;
        }
    }
}
