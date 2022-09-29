using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance => _instance;

    private static string mainMenuScene = "MainMenu";
    private static string levelSelectScene = "LevelSelect";
    private static List<string> levels = new List<string> {
        "TutorialLevel1",
        "TutorialLevel2",
        "Level1",
        "TutorialLevel3",
        "Level2",
        "Level3",
        "TutorialLevel4",
        "TutorialLevel5",
    };

    private int current;

    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        _instance = this;

        string currentScene = SceneManager.GetActiveScene().name;
        if (Debug.isDebugBuild)
        {
            if (currentScene != mainMenuScene && currentScene != levelSelectScene && !levels.Contains(currentScene))
            {
                // When running test scenes, add it to level manager so the API works
                levels.Add(currentScene);
                Debug.Log("Added current scene to level manager for debug purposes.");
            }
        }
        current = levels.IndexOf(SceneManager.GetActiveScene().name);
        DontDestroyOnLoad(this.gameObject);
    }

    public void NextLevel()
    {
        if (current == -1) return;
        current++;
        if (current >= levels.Count)
        {
            MainMenu();
        }
        else
        {
            SceneManager.LoadScene(levels[current], LoadSceneMode.Single);
        }
    }

    public List<string> GetLevels()
    {
        return levels;
    }

    public void JumpToLevel(string levelName)
    {
        int lvl = levels.IndexOf(levelName);
        if (lvl >= 0)
        {
            current = lvl;
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        }
    }

    public string GetCurrentLevel()
    {
        if (current == -1)
        {
            return SceneManager.GetActiveScene().name;
        }
        return levels[current];
    }

    public void RestartLevel()
    {
        if (current == -1) return;
        SceneManager.LoadScene(levels[current], LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        current = -1;
        SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Single);
    }
    
    public void LevelSelect()
    {
        current = -1;
        SceneManager.LoadScene(levelSelectScene, LoadSceneMode.Single);
    }
}
