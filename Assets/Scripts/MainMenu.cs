using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartMenuUI;
    public GameObject DroppedObject;
    public Material mat;

    public float timeBetweenDrops = .5f;
    float nextDrop;

    void Awake()
    {
        nextDrop = 1f;
    }

    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && (nextDrop < Time.time))
        {
            nextDrop = Time.time + timeBetweenDrops;
            float randX = Random.Range(-10.5f, 10.5f);
            float randY = Random.Range(-4f, 10.5f);
            GameObject Duck = Instantiate(DroppedObject, new Vector3(randX, randY, 0), Quaternion.Euler(new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f))));
            Destroy(Duck, 10f);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelS");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
