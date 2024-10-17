using UnityEngine;

public class DoubleJumpPowerUp : MonoBehaviour
{
    // When the player collides with the power-up
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the double jump ability in the player
            DoubleJump DoubleJump = other.GetComponent<DoubleJump>();
            if (DoubleJump != null)
            {
                DoubleJump.ActivateDoubleJump();
            }

            // Destroy the power-up object after it is collected
            Destroy(gameObject);
        }
    }
}
