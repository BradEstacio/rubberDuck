using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // General script that allows objects to rotate

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
    }
}
