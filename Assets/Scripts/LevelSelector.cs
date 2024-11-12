using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public string level;

    public void OpenScene()
    {
        SceneManager.LoadScene(level);
    }
}
