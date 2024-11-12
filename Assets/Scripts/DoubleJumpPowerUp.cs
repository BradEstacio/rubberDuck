using UnityEngine;

public class DoubleJumpPowerUp : MonoBehaviour
{
    // When the player collides with the power-up
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the double jump ability in the player
            PlayerController Player = other.GetComponent<PlayerController>();
            if (Player != null)
            {
                Player.ActivateDoubleJump();
            }

            // Destroy the power-up object after it is collected
            Destroy(gameObject);
        }
    }
}
