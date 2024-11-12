using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAnimations : MonoBehaviour
{
    public Animator bugAnim;
    private Rigidbody rb;
    public bool facingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        facingRight = true;
    }

    void Update()
    {
        // CheckFlip();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            Debug.Log("Dying animation");
            bugAnim.SetTrigger("Die");
        }
    }

    // private void CheckFlip()
    // {
    //     if(rb.velocity.x > 0 && !facingRight)
    //     {
    //         Flip();
    //     }
    //     else if(rb.velocity.x < 0 && facingRight)
    //     {
    //         Flip();
    //     }
    // }

    // private void Flip()
    // {
    //     facingRight = !facingRight;

    //     Vector3 theScale = transform.localScale;

    //     theScale.z *= -1;
    //     transform.localScale = theScale;  
    // }
}
