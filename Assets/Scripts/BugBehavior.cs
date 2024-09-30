using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBehavior : MonoBehaviour
{
    public GameObject bug;
    public GameObject quacked;

    // For timing between "Bug" (enemy) and "Quacked" (functional object) state
    public float lastCompletedCycleTime;

    void Awake()
    {
        lastCompletedCycleTime = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Bug is temporarily transformed into an object that can be used by the player
    public void QuackState(string bugName, float interval)
    {
        if((Time.time - lastCompletedCycleTime) >= interval)
        {
            Debug.Log("Transform to Quacked State...");
            bug.gameObject.SetActive(false);
            quacked.gameObject.SetActive(true);
        }
        Debug.Log("Reverting to Bug State...");
        quacked.gameObject.SetActive(false);
        bug.gameObject.SetActive(true);
        lastCompletedCycleTime = Time.time;
    }
}
