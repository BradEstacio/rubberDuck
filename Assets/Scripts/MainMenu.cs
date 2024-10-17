using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartMenuUI;
    public GameObject DroppedObject;

    public float timeBetweenDrops = 1f;
    float nextDrop;

    void Awake()
    {
        nextDrop = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && (nextDrop < Time.time))
        {
            nextDrop = Time.time + timeBetweenDrops;
            Debug.Log("Duck dropped.");
            Instantiate(DroppedObject, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Sandbox");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
