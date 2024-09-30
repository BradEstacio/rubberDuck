using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceSpeed;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("On bouncepad");
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceSpeed, ForceMode.Impulse);
        }    
    }
}
