using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderReposition : MonoBehaviour
{
    public GameObject block;
    public GameObject spider;

    // Update is called once per frame
    void Update()
    {
        spider.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - 0.6f, block.transform.position.z);
    }
}
