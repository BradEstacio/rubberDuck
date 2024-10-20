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
        for(int i = 0; i < 5; i++)
        {
            float randX = Random.Range(-10f, 10f);
            float randY = Random.Range(-4f, 8f);
            GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.position = new Vector3(randX, randY, 0);
            cylinder.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
            cylinder.GetComponent<Renderer>().material = mat;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && (nextDrop < Time.time))
        {
            nextDrop = Time.time + timeBetweenDrops;
            float randX = Random.Range(-10f, 10f);
            float randY = Random.Range(-4f, 8f);
            GameObject Duck = Instantiate(DroppedObject, new Vector3(randX, randY, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
            Destroy(Duck, 10f);
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
