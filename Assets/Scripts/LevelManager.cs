using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance => _instance;
    
    private static readonly string[] levels =
    {
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
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        _instance = this;
        current = Array.IndexOf(levels, SceneManager.GetActiveScene().name);
        DontDestroyOnLoad(this.gameObject);
    }

    public void NextLevel()
    {
        if (current == -1) return;
        current++;
        if (current >= levels.Length)
        {
            current = -1;
            MainMenu();
            return;
        }
        SceneManager.LoadScene(levels[current], LoadSceneMode.Single);
    }

    public string[] GetLevels()
    {
        return levels;
    }

    public void JumpToLevel(string levelName)
    {
        int lvl = Array.IndexOf(levels, levelName);
        if (lvl >= 0)
        {
            current = lvl;
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        }
    }

    public string GetCurrentLevel()
    {
        return levels[current];
    }

    public void RestartLevel()
    {
        if (current == -1) return;
        SceneManager.LoadScene(levels[current], LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }
}
