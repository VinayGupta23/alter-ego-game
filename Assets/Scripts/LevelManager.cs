using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class GameProgress
{
    // Workaround: Unity does not support serialization of hashsets :(
    // Using a synchronized storage with lists for writing/reading to file.
    [Serializable]
    private class SerializableGameProgress
    {
        public List<string> completedLevels = new List<string>();
        public List<string> gemCollectedLevels = new List<string>();
    }

    private HashSet<string> completedLevels;
    private HashSet<string> gemCollectedLevels;
    private SerializableGameProgress serializable;

    public bool IsCompleted(string levelName)
    {
        return completedLevels.Contains(levelName);
    }

    public bool IsGemCollected(string levelName)
    {
        return gemCollectedLevels.Contains(levelName);
    }

    public int Gems()
    {
        return gemCollectedLevels.Count;
    }

    public void MarkComplete(string levelName, bool gemCollected = false)
    {
        bool success = completedLevels.Add(levelName);
        if (success)
        {
            serializable.completedLevels.Add(levelName);
        }

        if (gemCollected)
        {
            success = gemCollectedLevels.Add(levelName);
            if (success)
            {
                serializable.gemCollectedLevels.Add(levelName);
            }
        }
    }

    public void Reset()
    {
        completedLevels.Clear();
        gemCollectedLevels.Clear();
        
        serializable.completedLevels.Clear();
        serializable.gemCollectedLevels.Clear();
    }

    private static readonly string VERSION_KEY = "version";
    private static readonly string PROGRESS_KEY = "progress";

    public static GameProgress Load()
    {
        GameProgress gp = new GameProgress();
        string version = PlayerPrefs.GetString(VERSION_KEY, "");
        string progressRaw = PlayerPrefs.GetString(PROGRESS_KEY, "{}");

        if (version != Application.version)
        {
            gp.serializable = new SerializableGameProgress();
            gp.completedLevels = new HashSet<string>();
            gp.gemCollectedLevels = new HashSet<string>();

            // Overwrite any obsolete data as the version changed
            Save(gp);
        }
        else
        {
            gp.serializable = JsonUtility.FromJson<SerializableGameProgress>(progressRaw);
            gp.completedLevels = new HashSet<string>(gp.serializable.completedLevels);
            gp.gemCollectedLevels = new HashSet<string>(gp.serializable.gemCollectedLevels);
        }

        return gp;
    }

    // Note: This updates the PlayerPrefs object, not directly the underlying storage.
    //       Unity automatically writes to storage when application is closed.
    public static void Save(GameProgress gp)
    {
        PlayerPrefs.SetString(VERSION_KEY, Application.version);
        string progressRaw = JsonUtility.ToJson(gp.serializable);
        PlayerPrefs.SetString(PROGRESS_KEY, progressRaw);
    }
}


public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance => _instance;

    private static string mainMenuScene = "MainMenu";
    private static string levelSelectScene = "LevelSelect";
    private static List<string> levels = new List<string> {
        "0-1",
        "0-2",
        "0-3",
        "1-1",
        "1-2",
        "1-3",
        "2-1",
        "2-2",
        "2-3",
        "2-4",
        "2-5",
        "3-1",
        "3-2",
        "3-3",
        "4-1",
        "4-2",
        "4-3",
        "5-1",
        "5-2",
        "5-3"
    };

    private int current;
    
    private GameProgress _gameProgress;
    public GameProgress GameProgress => _gameProgress;

    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;

        current = levels.IndexOf(SceneManager.GetActiveScene().name);
        _gameProgress = GameProgress.Load();

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
        
        Analytics.Instance.SetLevelStopwatch(Stopwatch.StartNew());
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
        
        Analytics.Instance.SetLevelStopwatch(Stopwatch.StartNew());
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
}
