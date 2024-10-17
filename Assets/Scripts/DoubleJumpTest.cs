using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoubleJump : MonoBehaviour
{
    // Player movement
    public float moveSpeed = 20f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    public bool facingRight;

    // Double jump
    public int maxJumps = 1;        // Start with 1 jump (no double jump)
    private int jumpCount = 0;      // Tracks how many jumps the player has done
    private bool canDoubleJump = false; // Tracks if double jump is currently enabled

    // Player shooting
    public float timeBetweenShots = 1f;
    float nextShot;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public AudioClip shootSound;
    private AudioSource audioSource;

    void Awake()
    {
        nextShot = 1f;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        facingRight = true;

        // Ensure maxJumps is set to 1 (no double jump at start)
        maxJumps = 1;
    }

    void Update()
    {
        Move();

        if (Input.GetButtonDown("Jump"))
        {
            // Allow jumping if the player is grounded or has available jumps (double jump when enabled)
            if (IsGrounded() || jumpCount < maxJumps)
            {
                Jump();
            }
        }

        if (Input.GetMouseButton(0) && (nextShot < Time.time))
        {
            nextShot = Time.time + timeBetweenShots;

            // Shooting Logic
            if (facingRight)
            {
                Shoot(Vector3.right); // Shoot right
            }
            else if (!facingRight)
            {
                Shoot(Vector3.left); // Shoot left
            }
        }

        // Temporary level reset functionality
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, 0);
        rb.velocity = movement;

        if ((moveHorizontal > 0) && !facingRight)
        {
            Debug.Log("Facing right.");
            Flip();
        }
        else if ((moveHorizontal < 0) && facingRight)
        {
            Debug.Log("Facing left.");
            Flip();
        }
    }

    private void Jump()
    {
        // Apply jump force
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpCount++;  // Increment jump count after each jump
    }

    private bool IsGrounded()
    {
        // Ground detection using raycast
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            jumpCount = 0;  // Reset the jump count when grounded
            return true;
        }
        return false;
    }

    private void Shoot(Vector3 direction)
    {
        GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetDirection(direction); // Set direction for the bullet
        PlayShootSound();
    }

    private void PlayShootSound()
    {
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.z *= -1;
        transform.localScale = theScale;
    }

    // Method to activate the double jump ability
    public void ActivateDoubleJump()
    {
        maxJumps = 2;  // Allow double jump
        StartCoroutine(DoubleJumpTimer());
    }

    // Coroutine to disable double jump after 10 seconds
    private IEnumerator DoubleJumpTimer()
    {
        yield return new WaitForSeconds(10f);
        maxJumps = 1;  // Disable double jump after 10 seconds
    }
}
