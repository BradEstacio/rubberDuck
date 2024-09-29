using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // Speed of the bullet
    public float lifespan; // Time in seconds before the bullet despawns
    private Vector3 direction;

    void Start()
    {
        // Destroy the bullet after 'lifespan' seconds
        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        // Move the bullet in the set direction
        transform.position += direction * speed * Time.deltaTime;
    }

    // Set the direction of the bullet
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized; // Normalize the direction
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if projectile collided with a game object named "Enemy"
        if(collision.gameObject.name == "Enemy")
        {
            Debug.Log("Enemy hit!");
            Debug.Log(collision.gameObject.tag);

            // Bullet is destroyed upon collision with an enemy
            Destroy(gameObject);
        }
    }
}
