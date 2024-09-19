using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerObj;
    public Rigidbody rb;

    public float moveSpeed;

    public bool grounded;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Player moves via WAD keys
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        // Left / Right / Jump
        if(Mathf.Abs(rb.velocity.x) < 8)
        {
            rb.AddRelativeForce(Vector3.right * xInput * Time.deltaTime * moveSpeed);

            if(rb.velocity.x > 0 && !facingRight)
            {
                Flip();
            }
            else if(rb.velocity.x < 0 && facingRight)
            {
                Flip();
            }
        }

        if(Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.AddRelativeForce(Vector3.up * 1470);
        }

        // Jump once ONLY when on the Ground
        if(!grounded)
        {
            rb.AddRelativeForce(Vector3.down * 1960 * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Debug.Log("Key get!");
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    void Flip()
    {
        facingRight = !facingRight;
    }

    public float GetFacing()
    {
        if(facingRight)
        {
            return 1f;
        }
        else
        {
            return -1f;
        }
    }
}