using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance => _instance;

    private static string mainMenuScene = "MainMenu";
    private static string levelSelectScene = "LevelSelect";
    private static List<string> levels = Constants.LevelNames;

    private int _current;
    private int _previous = -1;

    public int current
    {
        get { return _current; }
        private set 
        { 
            previous = _current;
            _current = value;
        }
    }

    public int previous
    {
        get { return _previous; }
        private set { _previous = value; }
    }

    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;

        current = levels.IndexOf(SceneManager.GetActiveScene().name);
        DontDestroyOnLoad(this.gameObject);
    }

    public void NextLevel()
    {
        if (Debug.isDebugBuild)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene != mainMenuScene && currentScene != levelSelectScene && !levels.Contains(currentScene))
            {
                // This is a test scene not part of level sequence
                MainMenu();
            }
        }

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
        
        Analytics.Instance.SetAttemptStopwatch(Stopwatch.StartNew());
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
        
        Analytics.Instance.SetAttemptStopwatch(Stopwatch.StartNew());
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
        if (Debug.isDebugBuild)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene != mainMenuScene && currentScene != levelSelectScene && !levels.Contains(currentScene))
            {
                // This is a test scene not part of level sequence
                SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
            }
        }

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

    public void PreviousScene()
    {
        if (previous == -1)
        {
            MainMenu();
        }
        else
        {
            JumpToLevel(levels[previous]);
        }
    }
}
