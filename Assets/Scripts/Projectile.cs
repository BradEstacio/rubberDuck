using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // Speed of the bullet
    public float lifespan; // Time in seconds before the bullet despawns
    private Vector3 direction;

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
        // Check if projectile collided with a game object named "Enemy"
        if(collision.gameObject.name == "Enemy")
        {
            BugBehavior theBug = collision.gameObject.transform.parent.gameObject.GetComponent<BugBehavior>();

            Debug.Log("Enemy hit!");
            Debug.Log(collision.gameObject.transform.parent.gameObject);
            Debug.Log(collision.gameObject.tag);

            // Bullet is destroyed upon collision with an enemy
            Destroy(gameObject);

            // Switch statement to call upon a timer function depending on the bug
            switch(collision.gameObject.tag)
            {
                case "Ant":
                    theBug.QuackState(collision.gameObject.tag, 3f);
                    break;
                case "Moth":
                    theBug.QuackState(collision.gameObject.tag, 7f);
                    break;
                case "Spider":
                    theBug.QuackState(collision.gameObject.tag, 7.5f);
                    break;
            }
        }
    }
}