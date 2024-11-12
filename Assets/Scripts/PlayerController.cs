using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Player + Duck animation
    public Animator thorAnim;
    public Animator duckAnim;

    // Player movement
    public float moveSpeed = 20f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    public bool facingRight;

    // Player shooting
    public float timeBetweenShots = 0.5f;
    float nextShot;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public AudioClip shootSound;
    private AudioSource audioSource;

    // Double jump
    public int maxJumps = 1;        // Start with 1 jump (no double jump)
    private int jumpCount = 0;      // Tracks how many jumps the player has done
    //private bool canDoubleJump = false; // Tracks if double jump is currently enabled

    // For collectibles
    public int keyCount;
    [SerializeField] private string levelName;

    void Awake()
    {
        nextShot = 0.25f;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        facingRight = true;
        keyCount = 0;
    }

    void Update()
    {
        Move();

        //isGrounded = IsGrounded();

        // Allow jumping if the player is grounded or has available jumps (double jump when enabled)
        if(IsGrounded() || jumpCount < maxJumps)
        {
            if(Input.GetButtonDown("Jump"))
            {
                    Jump();
            }
        }


        if(Input.GetMouseButton(0) && (nextShot < Time.time))
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
        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            switch(other.gameObject.name)
            {
                case "Key":
                    other.gameObject.SetActive(false);
                    keyCount += 1;
                    Debug.Log("Key Count: " + keyCount);
                    break;
                case "Finish":
                    Debug.Log("Next level!");
                    SceneManager.LoadScene(levelName);
                    break;
            }
        }
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, 0);
        rb.velocity = movement;

        thorAnim.SetFloat("Speed", Mathf.Abs(moveHorizontal * moveSpeed));
        duckAnim.SetFloat("Speed", Mathf.Abs(moveHorizontal * moveSpeed));

        if((moveHorizontal > 0) && !facingRight)
        {
            Debug.Log("Facing right.");
            Flip();
        }
        else if((moveHorizontal < 0) && facingRight)
        {
            Debug.Log("Facing left.");
            Flip();
        }
    }

    private void Jump()
    {
        thorAnim.SetTrigger("Jump");
        duckAnim.SetTrigger("Jump");
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpCount++;
    }

    private bool IsGrounded()
    {
        // Ground detection using raycast
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            jumpCount = 0;  // Reset the jump count when grounded
            thorAnim.SetBool("Grounded", true);
            duckAnim.SetBool("Grounded", true);
            return true;
        }
        thorAnim.SetBool("Grounded", false);
        duckAnim.SetBool("Grounded", false);
        return false;
    }

    private void Shoot(Vector3 direction)
    {
        thorAnim.SetTrigger("Attack");
        duckAnim.SetTrigger("Attack");
        StartCoroutine(ShootDelay(direction, 0.37f)); // Code that delayed bullet shooting out when attack animation was slower
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

    public IEnumerator ShootDelay(Vector3 direction, float timer)
    {
        yield return new WaitForSeconds(timer);
        GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetDirection(direction); // Set direction for the bullet
        PlayShootSound();
    }

    // Method to activate the double jump ability
    public void ActivateDoubleJump()
    {
        Debug.Log("Double jump activated.");
        maxJumps = 2;  // Allow double jump
        StartCoroutine(DoubleJumpTimer());
    }

    // Coroutine to disable double jump after 10 seconds
    private IEnumerator DoubleJumpTimer()
    {
        yield return new WaitForSeconds(10f);
        maxJumps = 1;  // Disable double jump after 10 seconds
    }

    // Play jump animations when colliding with a BouncePad
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "BouncePad")
        {
            thorAnim.SetTrigger("Jump");
            duckAnim.SetTrigger("Jump");
        }
        // else if(collision.gameObject.name == "PushBlock")
        // {
        //     thorAnim.SetTrigger("Push");
        //     duckAnim.SetTrigger("Push");
        // }
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "PushBlock")
        {
            thorAnim.SetBool("PushingBlock", true);
            duckAnim.SetBool("PushingBlock", true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        thorAnim.SetBool("PushingBlock", false);
        duckAnim.SetBool("PushingBlock", false);
    }
}
