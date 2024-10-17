using UnityEngine;

public class Deathwall : MonoBehaviour
{
    public float speed = 5f;  // Speed of the deathwall
    public float delayBeforeDestruction = 5f;  // Time delay before deletion

    void Update()
    {
        // Move the deathwall along the x-axis
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    // Detect collisions with objects
    private void OnTriggerEnter(Collider other)
    {
        // Destroy the object 5 seconds after collision
        Destroy(other.gameObject, delayBeforeDestruction);
    }
}
