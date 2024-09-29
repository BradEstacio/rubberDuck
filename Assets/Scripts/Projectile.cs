using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Speed of the bullet
    public float lifespan = 3f; // Time in seconds before the bullet despawns
    private Vector3 direction;

    void Start()
    {
        // Destroy the bullet after 'lifespan' seconds
        Destroy(gameObject, lifespan);
    }

    // Set the direction of the bullet
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized; // Normalize the direction
    }

    void Update()
    {
        // Move the bullet in the set direction
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Optional: Destroy the bullet on collision
       // Destroy(gameObject);
    }
}
