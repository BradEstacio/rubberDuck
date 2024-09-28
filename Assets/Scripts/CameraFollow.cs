using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // The player's transform
    public float smoothing = 0.125f;  // Smoothing speed of the camera
    public Vector3 offset;  // Offset position from the player

    void LateUpdate()
    {
        // Desired position is the player's position with the offset
        Vector3 desiredPosition = player.position + offset;

        // Smoothly interpolate between the current camera position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing);

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
