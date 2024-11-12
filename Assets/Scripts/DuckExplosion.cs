using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckExplosion : MonoBehaviour
{
    public GameObject duckPrefab; // Assign your duck prefab here
    public int duckCount = 10; // Number of ducks to spawn
    public float explosionForce = 10f; // Force applied to each duck
    public float explosionRadius = 5f; // Radius within which ducks are spawned
    public float upwardForce = 1f; // Add some upward force to simulate an explosion

    public float duckLifetime = 2f; // How long each duck instance lasts before disappearing

    public void Explode()
    {
        for (int i = 0; i < duckCount; i++)
        {
            // Random position within a sphere
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * explosionRadius;

            // Spawn the duck prefab at the random position
            GameObject duck = Instantiate(duckPrefab, spawnPosition, Random.rotation);

            // Add a Rigidbody if it doesn’t have one already
            Rigidbody rb = duck.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = duck.AddComponent<Rigidbody>();
            }

            // Add force to simulate explosion
            Vector3 forceDirection = (duck.transform.position - transform.position).normalized;
            rb.AddForce(forceDirection * explosionForce + Vector3.up * upwardForce, ForceMode.Impulse);

            // Destroy duck after a set lifetime
            Destroy(duck, duckLifetime);
        }
    }
}
