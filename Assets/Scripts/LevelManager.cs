using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static readonly string[] scenes =
    {
        "Level2Tiled",
        "Level2",
    };

    private int current = 0;

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("LevelManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void NextLevel()
    {
        current++;
        Debug.Log(current);
        if (current >= scenes.Length)
        {
            current = 0;
        }
        SceneManager.LoadScene(scenes[current], LoadSceneMode.Single);
    }
}
