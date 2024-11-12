using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // The player's transform
    public float smoothing;  // Smoothing speed of the camera
    public Vector3 offset;  // Offset position from the player

    // public float boundX = 2f;
    // public float boundY = 1.5f;

    private Rigidbody playerRB;

    private float idleTime = 0f;
    private bool idlePan = false;

    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Mathf.Abs(playerRB.velocity.x) == 0)
        {
            idleTime += Time.deltaTime;
        }
        else
        {
            idleTime = 0;
        }

        if(idleTime >= 1.5f)
        {
            idlePan = true;
        }
        else
        {
            idlePan = false;
        }
    }

    void LateUpdate()
    {
        // Vector3 delta = Vector3.zero;

        // float dx = player.position.x - transform.position.x;
        // float dy = player.position.y - transform.position.y;

        // if(dx > boundX || dx < -boundX)
        // {
        //     if(transform.position.x < player.position.x)
        //     {
        //         delta.x = dx - boundX;
        //     }
        //     else
        //     {
        //         delta.x = dx + boundX;
        //     }
        // }  

        // if(dy > boundY || dy < -boundY)
        // {
        //     if(transform.position.y < player.position.y)
        //     {
        //         delta.y = dy - boundY;
        //     }
        //     else
        //     {
        //         delta.y = dy + boundY;
        //     }
        // }   

        // Vector3 desiredPosition = transform.position + delta;
        // transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothing);

        if(!idlePan)
        {
            // Desired position is the player's position with the offset
            Vector3 desiredPosition = player.position + offset;

            // Smoothly interpolate between the current camera position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 1f);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
        else
        {
            Vector3 desiredPosition = player.position + new Vector3(1f, 1f, -20f);

            // Smoothly interpolate between the current camera position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.05f);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}
