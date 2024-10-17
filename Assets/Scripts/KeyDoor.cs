using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    public GameObject keyDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.keyCount -= 1;
            Debug.Log("Key Count: " + player.keyCount);
            keyDoor.gameObject.SetActive(false);
        }
    }
}
