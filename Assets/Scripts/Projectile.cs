using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // Speed of the bullet
    public float lifespan; // Time in seconds before the bullet despawns
    private Vector3 direction;

    public GameObject duckExplosionPrefab; // Reference to the Duck Explosion prefab

    void Start()
    {
        // Destroy the bullet after 'lifespan' seconds - if it has not collided with an enemy
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
        // Check if projectile collided with a game object
        // You can customize this check as per your game logic
        if (collision.gameObject.name == "Enemy")
        {
            // If the bullet hits an enemy, destroy it and trigger explosion
            Destroy(gameObject);

            TriggerDuckExplosion(collision.transform.position);

            // Switch statement to call upon a timer function depending on the bug
            switch(collision.gameObject.tag)
            {
                case "Ant":
                    theBug.QuackState(collision.gameObject.tag, 3f);
                    break;
                case "Moth":
                    theBug.QuackState(collision.gameObject.tag, 5f);
                    break;
                case "Spider":
                    theBug.QuackState(collision.gameObject.tag, 5f);
                    break;
            }
        }
    }

    // This function will instantiate the Duck Explosion at the bullet's position
    void TriggerDuckExplosion(Vector3 position)
    {
        // Instantiate the DuckExplosion effect at the bullet's position
        GameObject explosion = Instantiate(duckExplosionPrefab, position, Quaternion.identity);

        // Optionally, you could directly call the Explode() method here
        DuckExplosion duckExplosionScript = explosion.GetComponent<DuckExplosion>();
        if (duckExplosionScript != null)
        {
            duckExplosionScript.Explode(); // Trigger the explosion
        }
    }
}
