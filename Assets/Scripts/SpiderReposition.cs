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
        spider.transform.position = block.transform.position;
    }
}
