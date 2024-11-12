using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 5f; // Distance the platform will travel
    public float moveSpeed = 2f;    // Speed of movement
    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        // Store the starting position of the platform
        startPos = transform.position;
    }

    void Update()
    {
        // Determine the target position
        Vector3 targetPos = startPos + (movingRight ? Vector3.right : Vector3.left) * moveDistance;

        // Move the platform toward the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            movingRight = !movingRight; // Reverse direction
        }
    }
}
