using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static readonly string[] scenes =
    {
        "MainMenu",
        "LevelSelect",
        "TutorialLevel1",
        "TutorialLevel2",
        "Level1",
        "TutorialLevel3",
        "Level2",
        "Level3"
    };

    private int current;

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("LevelManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        current = Array.IndexOf(scenes, SceneManager.GetActiveScene().name);
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

    public string[] GetLevels()
    {
        return scenes;
    }

    public void JumpToLevel(string levelName)
    {
        int lvl = Array.IndexOf(scenes, levelName);
        if (lvl >= 0)
        {
            current = lvl;
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        }
    }

    public string GetCurrentLevel()
    {
        return scenes[current];
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(scenes[current], LoadSceneMode.Single);
    }

}
