using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartMenuUI;
    public GameObject DroppedObject;

    public float timeBetweenDrops = .5f;
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
            Debug.Log("Duck dropped.");
            nextDrop = Time.time + timeBetweenDrops;
            float randX = Random.Range(-10f, 10f);
            float randY = Random.Range(-4f, 8f);
            Instantiate(DroppedObject, new Vector3(randX, randY, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
            //GameObject Duck = Instantiate(DroppedObject, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
            //DuckPachinko DuckGame = Duck.GetComponent<DuckPachinko>();
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
