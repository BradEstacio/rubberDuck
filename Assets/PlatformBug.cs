using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBug : MonoBehaviour
{
    public GameObject bug;
    public GameObject platform;
    public float enemyHealth = 1f;
    public float interval = 3f;
    public float lastCompletedCycleTime;
    // Start is called before the first frame update
    void Awake()
    {
        lastCompletedCycleTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Listen, the code is super broken right now so I have to do this.
        if((Time.time - lastCompletedCycleTime) >= interval){
            bug.gameObject.SetActive(true);
            platform.gameObject.SetActive(false);
        }
        if((Time.time - lastCompletedCycleTime) >= interval * 2){
            bug.gameObject.SetActive(false);
            platform.gameObject.SetActive(true);
            lastCompletedCycleTime = Time.time;
        }
    }

    public void addDamage(float damage) {
        Debug.Log("Enemy hit!");
        if(damage <= 0f){
            return;
        }
        enemyHealth -= damage;

        if(enemyHealth <= 0) {
            killBug();
            spawnPlatform();
            // StartCoroutine(ExampleCoroutine());
            respawnBug();
        }
    }

    // When bug is hit, the "bug" dissapears
    void killBug() {
        Destroy(gameObject.transform.root.gameObject);
    }

    // Bug is temporarily replaced by a platform
    void spawnPlatform() {
        Instantiate(platform, transform.position, transform.rotation);
    }

    // Platform dissapears and "reverts" back to the bug
    void respawnBug() {
        Destroy(gameObject.transform.root.gameObject);
        Instantiate(bug, transform.position, transform.rotation);
    }

    // Wait for 5 seconds
    // IEnumerator ExampleCoroutine() {
    //     Debug.Log("Started Coroutine at timestamp: " + Time.time);
    //     yield return new WaitForSeconds(2);
    //     Debug.Log("Finished Coroutine at timestamp: " + Time.time);
    // }
}
