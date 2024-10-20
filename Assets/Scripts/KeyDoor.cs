using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    public GameObject keyDoor;

    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.tag == "Player") && player.keyCount > 0)
        {
            player.keyCount -= 1;
            Debug.Log("Key Count: " + player.keyCount);
            keyDoor.gameObject.SetActive(false);
        }
    }
}
