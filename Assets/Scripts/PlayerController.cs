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
    public float timeBetweenShots = 1f;
    float nextShot;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public AudioClip shootSound;
    private AudioSource audioSource;

    // For collectibles
    public int keyCount;
    [SerializeField] private string levelName;

    void Awake()
    {
        nextShot = 1f;
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

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
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

    // void FixedUpdate()
    // {
    //     Move();
    // }

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
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    private void Shoot(Vector3 direction)
    {
        thorAnim.SetTrigger("Attack");
        duckAnim.SetTrigger("Attack");
        StartCoroutine(ShootDelay(direction, 0.5f)); // Code that delayed bullet shooting out when attack animation was slower
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
}
