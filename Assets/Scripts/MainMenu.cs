using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartMenuUI;
    public GameObject DroppedObject;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Debug.Log("Duck dropped.");
            Instantiate(DroppedObject, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
            //Instantiate(prefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
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
