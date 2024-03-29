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
    private static string creditScene = "Credits";
    private static List<string> levels = Constants.LevelNames;

    private int _current;
    private int _previous = -1;

    public int current
    {
        get { return _current; }
        private set 
        { 
            if (_current == levels.IndexOf("SECRET"))
            {
                // When navigating out of the secret level, delete the back pointer.
                // This is in case the player resets data while playing this level.
                previous = -1;
            }
            else
            {
                previous = _current;
            }
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
        if (current >= Constants.NormalLevelCount)
        {
            // Should not go to secret level after the last bonus level
            MainMenu();
        }
        else
        {
            //SceneManager.LoadScene(levels[current], LoadSceneMode.Single);
            LoadScene(levels[current]);
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
            //SceneManager.LoadScene(levelName, LoadSceneMode.Single);
            LoadScene(levelName);
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
                //SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
                LoadScene(currentScene);
            }
        }

        if (current == -1) return;
        //SceneManager.LoadScene(levels[current], LoadSceneMode.Single);
        LoadScene(levels[current]);
    }

    public void MainMenu()
    {
        current = -1;
        //SceneManager.LoadScene(mainMenuScene, LoadSceneMode.Single);
        LoadScene(mainMenuScene);
    }
    
    public void LevelSelect()
    {
        current = -1;
        //SceneManager.LoadScene(levelSelectScene, LoadSceneMode.Single);
        LoadScene(levelSelectScene);
    }

    public void Credits()
    {
        current = -1;
        LoadScene(creditScene);
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
    public void LoadScene(string levelname) {
        if (LevelDependency.Instance.DMInstance.IsLocked(levelname) == false)
        {
            SceneManager.LoadScene(levelname, LoadSceneMode.Single);
        }
        else {
            current = previous;
            Debug.LogWarning("Cannot load level " + levelname + " without meeting dependencies.");
            // Fallback to level select. Warning: This could lead to infinite recursion
            // if level select is locked unintentionally!
            LevelSelect();
        }
        
    }
}
